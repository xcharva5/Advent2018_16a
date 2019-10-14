using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018_16a
{
    class ProcessValidator
    {
        public static int Addr(InstructionProcess process)
        {
            // addr (add register) stores into register C the result of adding register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] + process.Before[process.Instruction[2]]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Addr);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Addi(InstructionProcess process)
        {
            // addi (add immediate) stores into register C the result of adding register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] + process.Instruction[2]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Addi);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Mulr(InstructionProcess process)
        {
            // mulr (multiply register) stores into register C the result of multiplying register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] * process.Before[process.Instruction[2]]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Mulr);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Muli(InstructionProcess process)
        {
            // muli (multiply immediate) stores into register C the result of multiplying register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] * process.Instruction[2]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Muli);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Banr(InstructionProcess process)
        {
            // banr (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] & process.Before[process.Instruction[2]]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Banr);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Bani(InstructionProcess process)
        {
            // bani (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] & process.Instruction[2]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Bani);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Borr(InstructionProcess process)
        {
            // borr (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] | process.Before[process.Instruction[2]]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Borr);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Bori(InstructionProcess process)
        {
            // bori (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] | process.Instruction[2]))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Bori);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Setr(InstructionProcess process)
        {
            // setr (set register) copies the contents of register A into register C. (Input B is ignored.)
            if (process.After[process.Instruction[3]] == process.Before[process.Instruction[1]])
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Setr);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Seti(InstructionProcess process)
        {
            // seti (set immediate) stores value A into register C. (Input B is ignored.)
            if (process.After[process.Instruction[3]] == process.Instruction[1])
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Seti);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Gtir(InstructionProcess process)
        {
            // gtir (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Instruction[1] > process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Instruction[1] <= process.Before[process.Instruction[2]])))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Gtir);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Gtri(InstructionProcess process)
        {
            // gtri (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] > process.Instruction[2])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] <= process.Instruction[2])))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Gtri);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Gtrr(InstructionProcess process)
        {
            // gtrr (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] > process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] <= process.Before[process.Instruction[2]])))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Gtrr);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Eqir(InstructionProcess process)
        {
            // eqir (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Instruction[1] == process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Instruction[1] != process.Before[process.Instruction[2]])))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Eqir);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Eqri(InstructionProcess process)
        {
            // eqri (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] == process.Instruction[2])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] != process.Instruction[2])))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Eqri);
                return 1;
            } else
            {
                return 0;
            }
        }

        public static int Eqrr(InstructionProcess process)
        {
            // eqrr (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] == process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] != process.Before[process.Instruction[2]])))
            {
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Eqrr);
                return 1;
            } else
            {
                return 0;
            }
        }


    }
}
