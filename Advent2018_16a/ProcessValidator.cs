namespace Advent2018_16a
{
    class ProcessValidator
    {
        public static void Addr(InstructionProcess process)
        {
            // addr (add register) stores into register C the result of adding register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] + process.Before[process.Instruction[2]]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Addr);
        }

        public static void Addi(InstructionProcess process)
        {
            // addi (add immediate) stores into register C the result of adding register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] + process.Instruction[2]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Addi);
        }

        public static void Mulr(InstructionProcess process)
        {
            // mulr (multiply register) stores into register C the result of multiplying register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] * process.Before[process.Instruction[2]]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Mulr);
        }

        public static void Muli(InstructionProcess process)
        {
            // muli (multiply immediate) stores into register C the result of multiplying register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] * process.Instruction[2]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Muli);
        }

        public static void Banr(InstructionProcess process)
        {
            // banr (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] & process.Before[process.Instruction[2]]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Banr);
        }

        public static void Bani(InstructionProcess process)
        {
            // bani (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] & process.Instruction[2]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Bani);
        }

        public static void Borr(InstructionProcess process)
        {
            // borr (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] | process.Before[process.Instruction[2]]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Borr);
        }

        public static void Bori(InstructionProcess process)
        {
            // bori (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
            if (process.After[process.Instruction[3]] == (process.Before[process.Instruction[1]] | process.Instruction[2]))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Bori);
        }

        public static void Setr(InstructionProcess process)
        {
            // setr (set register) copies the contents of register A into register C. (Input B is ignored.)
            if (process.After[process.Instruction[3]] == process.Before[process.Instruction[1]])
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Setr);
        }

        public static void Seti(InstructionProcess process)
        {
            // seti (set immediate) stores value A into register C. (Input B is ignored.)
            if (process.After[process.Instruction[3]] == process.Instruction[1])
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Seti);
        }

        public static void Gtir(InstructionProcess process)
        {
            // gtir (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Instruction[1] > process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Instruction[1] <= process.Before[process.Instruction[2]])))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Gtir);
        }

        public static void Gtri(InstructionProcess process)
        {
            // gtri (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] > process.Instruction[2])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] <= process.Instruction[2])))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Gtri);
        }

        public static void Gtrr(InstructionProcess process)
        {
            // gtrr (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] > process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] <= process.Before[process.Instruction[2]])))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Gtrr);
        }

        public static void Eqir(InstructionProcess process)
        {
            // eqir (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Instruction[1] == process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Instruction[1] != process.Before[process.Instruction[2]])))
                    process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Eqir);
        }

        public static void Eqri(InstructionProcess process)
        {
            // eqri (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] == process.Instruction[2])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] != process.Instruction[2])))
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Eqri);

        }

        public static void Eqrr(InstructionProcess process)
        {
            // eqrr (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
            if (((process.After[process.Instruction[3]] == 1) && (process.Before[process.Instruction[1]] == process.Before[process.Instruction[2]])) ||
                ((process.After[process.Instruction[3]] == 0) && (process.Before[process.Instruction[1]] != process.Before[process.Instruction[2]])))            
                process.PossibleOpCodes.Add(InstructionProcess.OPCodes.Eqrr);

        }


    }
}
