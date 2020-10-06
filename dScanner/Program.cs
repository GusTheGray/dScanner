using dScanner.Models;
using dScanner.Scanners;
using System;
using System.Threading.Tasks;
using System.Threading.Channels;
using System.Collections.Generic;

namespace dScanner
{
    class Program
    {
        static void Main(string[] args)
        {
//            var scanner = new NmapScanner();
//            var output = scanner.RunNmapScan("54.83.32.78");

            var pArgs = new ProgramArgumentsModel
            {
                InputFile = "test.txt",
                OutputFile = "results.txt",
                Jobs = 5
            };

            Console.WriteLine($"Beginning job run");
            var output = JobsRunner(pArgs).Result;
            Console.WriteLine($"Output: {output}");
        }

        public static async Task<string> JobsRunner(ProgramArgumentsModel args)
        {

            var inputChannel = Channel.CreateBounded<string>(
                new BoundedChannelOptions(1000)
                {
                    FullMode = BoundedChannelFullMode.Wait,
                    SingleReader = false,
                    SingleWriter = true
                });

            var resultChannel = Channel.CreateBounded<string>(
                new BoundedChannelOptions(1000)
                {
                    FullMode = BoundedChannelFullMode.Wait,
                    SingleReader = true,
                    SingleWriter = false
                });

            var resultsTask = Task.Run(() => ResultsWriterAsync(resultChannel.Reader, args.OutputFile));

            var Jobs = new List<Task>();
            for (int i = 0; i < args.Jobs; i++)
            {
                Jobs.Add(Task.Run(() => ScanRunner(inputChannel.Reader, resultChannel.Writer)));
            }
            var targets = System.IO.File.ReadLines(args.InputFile);
            foreach (var target in targets)
            {
                inputChannel.Writer.TryWrite(target);
            }
            inputChannel.Writer.Complete();
            await inputChannel.Reader.Completion;
            await Task.WhenAll(Jobs);

            resultChannel.Writer.TryComplete();

            await resultsTask;

            return "Jobs Completed";
        }

        private async static void ScanRunner(ChannelReader<string> inputReader, ChannelWriter<string> outputWriter)
        {
            var scanner = new NmapScanner();
            while (await inputReader.WaitToReadAsync())
            {
                string target;
                string output;

                while (inputReader.TryRead(out target))
                {
                    Console.WriteLine($"Scanning {target}");
                    output = scanner.RunNmapScan(target);

                    outputWriter.TryWrite($"Results for {target}\n{output}");
                }

            }

            //outputWriter.TryComplete();
        }

        private static async Task ResultsWriterAsync(ChannelReader<string> reader, string outputFile)
        {
            var outPuts = new List<string>();
            while (await reader.WaitToReadAsync())
            {
                while (reader.TryRead(out var result))
                {
                    outPuts.Add(result);
                }
            }

            System.IO.File.WriteAllLines(outputFile, outPuts);
        }
    }
}
