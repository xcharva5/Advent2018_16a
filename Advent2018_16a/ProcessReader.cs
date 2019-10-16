using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Advent2018_16a
{
    class ProcessReader
    {
        public List<InstructionProcess> ResultProcesses { get; set; }
        public List<InstructionTest> ResultTests { get; set; }
        public enum InputType { Before, After, Instruction, Empty }

        public ProcessReader()
        {
            ResultProcesses = new List<InstructionProcess>();
            ResultTests = new List<InstructionTest>();
        }

        public void LoadProcessesFromFile(string path)
        {
            string line;
            InputType previousInput = new InputType();
            StreamReader file = new StreamReader(path);
            Regex beforePattern = new Regex(@"Before: \[(\d),\s(\d),\s(\d),\s(\d)\]");
            Regex afterPattern = new Regex(@"After:  \[(\d),\s(\d),\s(\d),\s(\d)\]");
            Regex instructionPattern = new Regex(@"(\d+)\s(\d)\s(\d)\s(\d)");

            // have to initialize "process" before while bcs it's necessary to keep values between several lines
            InstructionProcess process = new InstructionProcess();
            // "test" can be initialized here but it's not necessary, bcs it has to also be initialised on other place
            InstructionTest test;

            // read each line of text file
            while ((line = file.ReadLine()) != null)
            {
                // recognizes to which pattern the line matches
                if (beforePattern.IsMatch(line))
                {      
                    // BEFORE REGISTERS
                    // initialize the array here to verify if the Before was filled
                    process.Before = new int[4];
                    for (int i = 0; i < process.Before.Length; i++)                    
                        process.Before[i] = int.Parse(beforePattern.Match(line).Groups[i + 1].Value);

                    #region REFACTORING
                    /*process.Before[0] = int.Parse(beforePattern.Match(line).Groups[1].Value);
                    process.Before[1] = int.Parse(beforePattern.Match(line).Groups[2].Value);
                    process.Before[2] = int.Parse(beforePattern.Match(line).Groups[3].Value);
                    process.Before[3] = int.Parse(beforePattern.Match(line).Groups[4].Value);*/
                    #endregion

                    previousInput = InputType.Before;
                } else if (instructionPattern.IsMatch(line))
                {
                    // there are 2 types of intructions -- learning and testing
                    // testing instructions can be preceded by other instruction or empty line
                    if (previousInput == InputType.Instruction || previousInput == InputType.Empty)
                    {
                        // TESTING INSTRUCTION
                        test = new InstructionTest();
                        test.Instruction = new int[4];
                        for (int i = 0; i < test.Instruction.Length; i++)
                            test.Instruction[i] = int.Parse(instructionPattern.Match(line).Groups[i + 1].Value);

                        #region REFACTORING
                        /*test.Instruction[0] = int.Parse(instructionPattern.Match(line).Groups[1].Value);
                        test.Instruction[1] = int.Parse(instructionPattern.Match(line).Groups[2].Value);
                        test.Instruction[2] = int.Parse(instructionPattern.Match(line).Groups[3].Value);
                        test.Instruction[3] = int.Parse(instructionPattern.Match(line).Groups[4].Value);*/
                        #endregion

                        // test instructions are one-line and can be stored immediately
                        ResultTests.Add(test);
                    } else
                    {
                        // LEARNING INSTRUCTION
                        process.Instruction = new int[4];
                        for (int i = 0; i < process.Instruction.Length; i++)
                            process.Instruction[i] = int.Parse(instructionPattern.Match(line).Groups[i + 1].Value);

                        #region REFACTORING
                        /*process.Instruction[0] = int.Parse(instructionPattern.Match(line).Groups[1].Value);
                        process.Instruction[1] = int.Parse(instructionPattern.Match(line).Groups[2].Value);
                        process.Instruction[2] = int.Parse(instructionPattern.Match(line).Groups[3].Value);
                        process.Instruction[3] = int.Parse(instructionPattern.Match(line).Groups[4].Value);*/
                        #endregion
                    }

                    previousInput = InputType.Instruction;
                }
                else if (afterPattern.IsMatch(line))
                {        
                    // AFTER REGISTERS
                    process.After = new int[4];
                    for (int i = 0; i < process.After.Length; i++)
                        process.After[i] = int.Parse(afterPattern.Match(line).Groups[i + 1].Value);

                    #region REFACTORING
                    /*process.After[0] = int.Parse(afterPattern.Match(line).Groups[1].Value);
                    process.After[1] = int.Parse(afterPattern.Match(line).Groups[2].Value);
                    process.After[2] = int.Parse(afterPattern.Match(line).Groups[3].Value);
                    process.After[3] = int.Parse(afterPattern.Match(line).Groups[4].Value);*/
                    #endregion

                    previousInput = InputType.After;
                } else if (!IsNullOrEmpty(process.Before) && !IsNullOrEmpty(process.Instruction) && !IsNullOrEmpty(process.After))
                {
                    // if line doesn't match any pattern and "Before", "Instruction" and "After" are filled, stores the process
                    ResultProcesses.Add(process);
                    // it's necessary to create a new instance of InstructionProcess 
                    process = new InstructionProcess();
                    previousInput = InputType.Empty;
                }
            }

            file.Close();

            // order processes by op code
            ResultProcesses = ResultProcesses.OrderBy(x => x.Instruction[0]).ToList();
        }

        private bool IsNullOrEmpty(Array array)
        {
            return (array == null || array.Length == 0);
        }
    }
}
