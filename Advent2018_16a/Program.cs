using System;
using System.Collections.Generic;

namespace Advent2018_16a
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessAnalyzer pa = new ProcessAnalyzer(ProcessReader.LoadProcessesFromFile("../../../input.txt"));
            pa.AnalyzeProcesses();
            Console.WriteLine("There is {0} instruction processes with 3+ possible OP codes.", pa.GetProcessesWithThreeOrMore());
            //pa.DisplayProcessesWithPossibleOPs();
            pa.SetNamesToOPCodes();

            Console.ReadLine();


        }
    }
}
