using System;
using System.Collections.Generic;

namespace Advent2018_16a
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessAnalyzer pa = new ProcessAnalyzer(ProcessReader.LoadProcessesFromFile("../../../input.txt"));
            Console.WriteLine("3+ possible OPCodes has {0} instrument processes", pa.AnalyzeProcesses());
            Console.ReadLine();


        }
    }
}
