using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018_16a
{
    class ProcessValidator
    {
        public static bool Addr(InstructionProcess process)
        {
            // addr (add register) stores into register C the result of adding register A and register B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] + process.Before[process.Instruction[2]]));
        }

        public static bool Addi(InstructionProcess process)
        {
            // addi (add immediate) stores into register C the result of adding register A and value B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] + process.Instruction[2]));
        }

        public static bool Mulr(InstructionProcess process)
        {
            // mulr (multiply register) stores into register C the result of multiplying register A and register B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] * process.Before[process.Instruction[2]]));
        }

        public static bool Muli(InstructionProcess process)
        {
            // muli (multiply immediate) stores into register C the result of multiplying register A and value B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] * process.Instruction[2]));
        }

        public static bool Banr(InstructionProcess process)
        {
            // banr (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] & process.Before[process.Instruction[2]]));
        }

        public static bool Bani(InstructionProcess process)
        {
            // bani (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] & process.Instruction[2]));
        }

        public static bool Borr(InstructionProcess process)
        {
            // borr (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] | process.Before[process.Instruction[2]]));
        }

        public static bool Bori(InstructionProcess process)
        {
            // bori (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.

            return (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] | process.Instruction[2]));
        }

        public static bool Setr(InstructionProcess process)
        {
            // setr (set register) copies the contents of register A into register C. (Input B is ignored.)

            return (process.After[process.Instruction[3]] == process.Before[process.Instruction[1]]);
        }

        public static bool Seti(InstructionProcess process)
        {
            // seti (set immediate) stores value A into register C. (Input B is ignored.)

            return (process.After[process.Instruction[3]] == process.Instruction[1]);
        }

        public static bool Gtir(InstructionProcess process)
        {
            // gtir (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.

            return (((process.After[process.Instruction[3]] == 1) && (process.Instruction[1] > process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Instruction[1] <= process.Before[process.Instruction[2]])));
        }

        public static bool Gtri(InstructionProcess process)
        {
            // gtri (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.

            return (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] > process.Instruction[2])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] <= process.Instruction[2])));
        }

        public static bool Gtrr(InstructionProcess process)
        {
            // gtrr (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.

            return (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] > process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] <= process.Before[process.Instruction[2]])));
        }

        public static bool Eqir(InstructionProcess process)
        {
            // eqir (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.

            return (((process.After[process.Instruction[3]] == 1) && (process.Instruction[1] == process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Instruction[1] != process.Before[process.Instruction[2]])));
        }

        public static bool Eqri(InstructionProcess process)
        {
            // eqri (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.

            return (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] == process.Instruction[2])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] != process.Instruction[2])));
        }

        public static bool Eqrr(InstructionProcess process)
        {
            // eqrr (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.

            return (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] == process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] != process.Before[process.Instruction[2]])));
        }


    }
}
