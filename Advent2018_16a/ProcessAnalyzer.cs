using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace Advent2018_16a
{
    class ProcessAnalyzer
    {
        public List<InstructionProcess> Processes { get; set; }

        public ProcessAnalyzer(List<InstructionProcess> processes)
        {
            Processes = processes;
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

        public int GetProcessesWithThreeOrMore()
        {
            return Processes.Count(p => p.PossibleOpCodes.Count >= 3);
        }

        public void DisplayProcessesWithPossibleOPs()
        {
            Processes = Processes.OrderBy(p => p.PossibleOpCodes.Count).ToList();

            foreach (InstructionProcess proc in Processes)
            {
                Console.WriteLine("{0} : {1}", proc.Instruction[0], string.Join(", ", proc.PossibleOpCodes));
            }
        }

        public void SetNamesToOPCodes()
        {
            List<InstructionProcess> processes = Processes.DistinctBy(p1 => p1.Instruction[0]).OrderBy(p => p.PossibleOpCodes.Count).ToList(); 

            Dictionary<int, InstructionProcess.OPCodes> opWithNames = new Dictionary<int, InstructionProcess.OPCodes>();

            foreach (InstructionProcess proc in processes)
            {
                Console.WriteLine("{0} : {1}", proc.Instruction[0], string.Join(", ", proc.PossibleOpCodes));
            }

            foreach (InstructionProcess proc in processes)
            {
                if (proc.PossibleOpCodes.Count == 1 && !opWithNames.ContainsKey(proc.Instruction[0]))
                {
                    InstructionProcess.OPCodes name = proc.PossibleOpCodes.First();
                    opWithNames.Add(proc.Instruction[0], name);
                    foreach (InstructionProcess pro in processes)
                    {
                        pro.PossibleOpCodes.Remove(name);
                        Console.WriteLine("{0} removed from number {1}", name, pro.Instruction[0]);
                    }
                } else
                {

                }

            }

            foreach (var item in opWithNames)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
        }
    }
}
