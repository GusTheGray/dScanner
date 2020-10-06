using System;
using System.Collections.Generic;
using System.Text;

namespace dScanner.Scanners
{
    public class NmapScanner
    {
        const string strCommand = "docker";
        const string strCommandParameters = "run kali-nmap nmap -A";
        System.Diagnostics.Process process;
        public NmapScanner()
        {
            this.process = new System.Diagnostics.Process();
            process.StartInfo.FileName = strCommand;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
        }
        public string RunNmapScan(string target)
        {
            process.StartInfo.Arguments = $"{strCommandParameters} {target}";
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
    }
}
