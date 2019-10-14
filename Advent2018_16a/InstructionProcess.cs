using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018_16a
{
    class InstructionProcess
    {
        public int[] Before { get; set; }
        public int[] After { get; set; }
        public int[] Instruction { get; set; }
        public List<OPCodes> PossibleOpCodes { get; set; }

        public InstructionProcess()
        {
            // the device has 4 registers (numbered 0 through 3)
            //Before = new int[4];  // state of registers BEFORE execution of the instruction
            //After = new int[4];  // state of registers AFTER execution of the instruction
            //Instruction = new int[4]; // [0] opcode, [1] input A, [2] input B, [3] output C
            PossibleOpCodes = new List<OPCodes>();
        }

        public enum OPCodes
        {
            Addr, Addi, Mulr, Muli, Banr, Bani, Borr, Bori, Setr, Seti, Gtir, Gtri, Gtrr, Eqir, Eqri, Eqrr
        }
    }
}
