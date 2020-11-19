using System;
using System.Collections.Generic;
using System.Text;

namespace dScanner.Repositories
{
    class LocalTextOutputRepository
    {
        public string outputFileName;
        public LocalTextOutputRepository(string outputFileName)
        {
            this.outputFileName = outputFileName;
        }

        public void RecordLog(string[] log)
        {
            System.IO.File.AppendAllLines(outputFileName, log); 
        }
    }
}
