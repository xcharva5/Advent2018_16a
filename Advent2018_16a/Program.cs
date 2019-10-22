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
            pa.DisplayProcessesWithThreeOrMore();
            pa.SetNamesToOPCodes();
            pa.RunTestingProgram();
        }
    }
}
