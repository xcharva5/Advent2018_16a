using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018_16a
{
    class ProcessAnalyzer
    {
        public List<InstructionProcess> Processes { get; set; }

        public ProcessAnalyzer(List<InstructionProcess> processes)
        {
            Processes = processes;
        }

        public int AnalyzeProcesses()
        {
            int threeOrMore = 0;

            foreach (InstructionProcess proc in Processes)
            {
                // each process should go through all kinds of validation
                int opCodesCounter = 0;
                opCodesCounter += ProcessValidator.Addi(proc);
                opCodesCounter += ProcessValidator.Addr(proc);
                opCodesCounter += ProcessValidator.Bani(proc);
                opCodesCounter += ProcessValidator.Banr(proc);
                opCodesCounter += ProcessValidator.Bori(proc);
                opCodesCounter += ProcessValidator.Borr(proc);
                opCodesCounter += ProcessValidator.Eqir(proc);
                opCodesCounter += ProcessValidator.Eqri(proc);
                opCodesCounter += ProcessValidator.Eqrr(proc);
                opCodesCounter += ProcessValidator.Gtir(proc);
                opCodesCounter += ProcessValidator.Gtri(proc);
                opCodesCounter += ProcessValidator.Gtrr(proc);
                opCodesCounter += ProcessValidator.Muli(proc);
                opCodesCounter += ProcessValidator.Mulr(proc);
                opCodesCounter += ProcessValidator.Seti(proc);
                opCodesCounter += ProcessValidator.Setr(proc);

                threeOrMore += (opCodesCounter >= 3) ? 1 : 0;

                if (opCodesCounter == 1)
                {
                    Console.WriteLine("Instruction ({0}) can be only 1 OP Code.", string.Join(",", proc.Instruction));
                }
            }

            return threeOrMore;
        }
    }
}
