using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MoreLinq;

namespace Advent2018_16a
{
    class ProcessAnalyzer
    {
        public List<InstructionProcess> Processes { get; set; }
        public List<InstructionTest> Tests { get; set; }
        public Dictionary<int, InstructionProcess.OPCodes> OpWithNames { get; set; }

        public ProcessAnalyzer(List<InstructionProcess> processes, List<InstructionTest> tests)
        {
            Processes = processes;
            Tests = tests;
        }

        public void AnalyzeProcesses()
        {
            foreach (InstructionProcess proc in Processes)
            {
                // each process should go through all kinds of validation
                ProcessValidator.Addi(proc);
                ProcessValidator.Addr(proc);
                ProcessValidator.Bani(proc);
                ProcessValidator.Banr(proc);
                ProcessValidator.Bori(proc);
                ProcessValidator.Borr(proc);
                ProcessValidator.Eqir(proc);
                ProcessValidator.Eqri(proc);
                ProcessValidator.Eqrr(proc);
                ProcessValidator.Gtir(proc);
                ProcessValidator.Gtri(proc);
                ProcessValidator.Gtrr(proc);
                ProcessValidator.Muli(proc);
                ProcessValidator.Mulr(proc);
                ProcessValidator.Seti(proc);
                ProcessValidator.Setr(proc);
            }
        }

        public void DisplayProcessesWithThreeOrMore()
        {
            Console.WriteLine("There is {0} instruction processes with 3+ possible OP codes.", Processes.Count(p => p.PossibleOpCodes.Count >= 3));
        }

        #region REFACTOR
        public void DisplayProcessesWithPossibleOPs()
        {
            Processes = Processes.OrderBy(p => p.PossibleOpCodes.Count).ToList();

            foreach (InstructionProcess proc in Processes)
            {
                Console.WriteLine("{0} : {1}", proc.Instruction[0], string.Join(", ", proc.PossibleOpCodes));
            }
        } 
        #endregion

        public void SetNamesToOPCodes()
        {
            // uses MoreLinq to distinct object
            List<InstructionProcess> processes = Processes.DistinctBy(p1 => p1.Instruction[0]).OrderBy(p => p.PossibleOpCodes.Count).ToList(); 

            OpWithNames = new Dictionary<int, InstructionProcess.OPCodes>();

            while (processes.Any())
            {
                InstructionProcess.OPCodes name = new InstructionProcess.OPCodes();

                foreach (InstructionProcess proc in processes)
                {
                    // if the proces has only 1 possibility and isn't recognised yet
                    if (proc.PossibleOpCodes.Count == 1 && !OpWithNames.ContainsKey(proc.Instruction[0]))
                    {
                        // var name has to be out of the loop because I use it for removing of possibilities
                        name = proc.PossibleOpCodes.First();
                        OpWithNames.Add(proc.Instruction[0], name);
                        processes.Remove(proc);
                        break;
                    }
                }

                processes.ForEach(p => p.PossibleOpCodes.RemoveAll(pop => pop == name));
            }

            #region REFACTORING
            /*OpWithNames = OpWithNames.OrderBy(op => op.Key).ToDictionary();

            foreach (var item in OpWithNames)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            } */
            #endregion
        }


        public void RunTestingProgram()
        {
            int[] registers = { 0, 0, 0, 0 };

            foreach (InstructionTest test in Tests)
            {
                Type type = typeof(ProcessExecutor);
                MethodInfo method = type.GetMethod(OpWithNames[test.Instruction[0]].ToString());
                ProcessExecutor c = new ProcessExecutor();
                registers = (int[])method.Invoke(c, new object[] { registers, test });

                #region REFACTORING
                /*switch (test.Instruction[0])
                        {
                            case 0:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[0].ToString());
                                registers = ProcessExecutor.Eqri(registers, test);
                                break;
                            case 1:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[1].ToString());
                                registers = ProcessExecutor.Bori(registers, test);
                                break;
                            case 2:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[2].ToString());
                                registers = ProcessExecutor.Addi(registers, test);
                                break;
                            case 3:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[3].ToString());
                                registers = ProcessExecutor.Bani(registers, test);
                                break;
                            case 4:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[4].ToString());
                                registers = ProcessExecutor.Seti(registers, test);
                                break;
                            case 5:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[5].ToString());
                                registers = ProcessExecutor.Eqrr(registers, test);
                                break;
                            case 6:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[6].ToString());
                                registers = ProcessExecutor.Addr(registers, test);
                                break;
                            case 7:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[7].ToString());
                                registers = ProcessExecutor.Gtri(registers, test);
                                break;
                            case 8:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[8].ToString());
                                registers = ProcessExecutor.Borr(registers, test);
                                break;
                            case 9:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[9].ToString());
                                registers = ProcessExecutor.Gtir(registers, test);
                                break;
                            case 10:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[10].ToString());
                                registers = ProcessExecutor.Setr(registers, test);
                                break;
                            case 11:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[11].ToString());
                                registers = ProcessExecutor.Eqir(registers, test);
                                break;
                            case 12:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[12].ToString());
                                registers = ProcessExecutor.Mulr(registers, test);
                                break;
                            case 13:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[13].ToString());
                                registers = ProcessExecutor.Muli(registers, test);
                                break;
                            case 14:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[14].ToString());
                                registers = ProcessExecutor.Gtrr(registers, test);
                                break;
                            case 15:
                                //Console.WriteLine("Test with OP: {0}", opWithNames[15].ToString());
                                registers = ProcessExecutor.Banr(registers, test);
                                break;
                            default:
                                Console.WriteLine("Something wrong");
                                break;

                        }*/ 
                #endregion
            }

            Console.WriteLine("Final registers: {0}", string.Join("-", registers));
        }
    }
}
