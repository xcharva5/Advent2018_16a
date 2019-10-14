using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Advent2018_16a
{
    class ProcessReader
    {        
        public static List<InstructionProcess> LoadProcessesFromFile(string path)
        {
            string line;
            StreamReader file = new StreamReader(path);
            Regex beforePattern = new Regex(@"Before: \[(\d),\s(\d),\s(\d),\s(\d)\]");
            Regex afterPattern = new Regex(@"After:  \[(\d),\s(\d),\s(\d),\s(\d)\]");
            Regex instructionPattern = new Regex(@"(\d+)\s(\d)\s(\d)\s(\d)");

            InstructionProcess process = new InstructionProcess();
            List<InstructionProcess> result = new List<InstructionProcess>();

            while ((line = file.ReadLine()) != null)
            {
                if (beforePattern.IsMatch(line))
                {
                    //Console.WriteLine("Before");
                    process.Before = new int[4];
                    process.Before[0] = int.Parse(beforePattern.Match(line).Groups[1].Value);
                    process.Before[1] = int.Parse(beforePattern.Match(line).Groups[2].Value);
                    process.Before[2] = int.Parse(beforePattern.Match(line).Groups[3].Value);
                    process.Before[3] = int.Parse(beforePattern.Match(line).Groups[4].Value);
                } else if (instructionPattern.IsMatch(line))
                {
                    // terminate while loop once it reaches test section of input file
                    if (IsNullOrEmpty(process.Before))
                    {
                        break;
                    }

                    //Console.WriteLine("Instruction");
                    process.Instruction = new int[4];
                    process.Instruction[0] = int.Parse(instructionPattern.Match(line).Groups[1].Value);
                    process.Instruction[1] = int.Parse(instructionPattern.Match(line).Groups[2].Value);
                    process.Instruction[2] = int.Parse(instructionPattern.Match(line).Groups[3].Value);
                    process.Instruction[3] = int.Parse(instructionPattern.Match(line).Groups[4].Value);
                } else if (afterPattern.IsMatch(line))
                {
                    //Console.WriteLine("After");
                    process.After = new int[4];
                    process.After[0] = int.Parse(afterPattern.Match(line).Groups[1].Value);
                    process.After[1] = int.Parse(afterPattern.Match(line).Groups[2].Value);
                    process.After[2] = int.Parse(afterPattern.Match(line).Groups[3].Value);
                    process.After[3] = int.Parse(afterPattern.Match(line).Groups[4].Value);
                } else if (!IsNullOrEmpty(process.Before) && !IsNullOrEmpty(process.Instruction) && !IsNullOrEmpty(process.After))
                {
                    result.Add(process);
                    process = new InstructionProcess();
                }
            }

            file.Close();

            return result.OrderBy(x => x.Instruction[0]).ToList();
        }

        private static bool IsNullOrEmpty(Array array)
        {
            return (array == null || array.Length == 0);
        }
    }
}
