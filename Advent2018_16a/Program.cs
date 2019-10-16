using System;
using System.Collections.Generic;

namespace Advent2018_16a
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessReader pr = new ProcessReader();
            pr.LoadProcessesFromFile("../../../input.txt");

            ProcessAnalyzer pa = new ProcessAnalyzer(pr.ResultProcesses, pr.ResultTests);
            pa.AnalyzeProcesses();
            Console.WriteLine("There is {0} instruction processes with 3+ possible OP codes.", pa.GetProcessesWithThreeOrMore());
            //pa.DisplayProcessesWithPossibleOPs();
            pa.SetNamesToOPCodes();
            pa.RunTestingProgram();

            Console.ReadLine();


        }
    }
}
