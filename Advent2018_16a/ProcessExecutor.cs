namespace Advent2018_16a
{
    class ProcessExecutor
    {
        public static int[] Addr(int[] registers, InstructionTest process)
        {
            // addr (add register) stores into register C the result of adding register A and register B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] + registers[process.Instruction[2]];

            return registers;
        }
        
        public static int[] Addi(int[] registers, InstructionTest process)
        {
            // addi (add immediate) stores into register C the result of adding register A and value B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] + process.Instruction[2];

            return registers;
        }
        
        public static int[] Mulr(int[] registers, InstructionTest process)
        {
            // mulr (multiply register) stores into register C the result of multiplying register A and register B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] * registers[process.Instruction[2]];

            return registers;
        }
        
        public static int[] Muli(int[] registers, InstructionTest process)
        {
            // muli (multiply immediate) stores into register C the result of multiplying register A and value B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] * process.Instruction[2];

            return registers;
        }

        public static int[] Banr(int[] registers, InstructionTest process)
        {
            // banr (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] & registers[process.Instruction[2]];

            return registers;
        }

        public static int[] Bani(int[] registers, InstructionTest process)
        {
            // bani (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] & process.Instruction[2];

            return registers;
        }

        public static int[] Borr(int[] registers, InstructionTest process)
        {
            // borr (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] | registers[process.Instruction[2]];

            return registers;
        }

        public static int[] Bori(int[] registers, InstructionTest process)
        {
            // bori (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
            registers[process.Instruction[3]] = registers[process.Instruction[1]] | process.Instruction[2];

            return registers;
        }

        public static int[] Setr(int[] registers, InstructionTest process)
        {
            // setr (set register) copies the contents of register A into register C. (Input B is ignored.)
            registers[process.Instruction[3]] = registers[process.Instruction[1]];

            return registers;
        }

        public static int[] Seti(int[] registers, InstructionTest process)
        {
            // seti (set immediate) stores value A into register C. (Input B is ignored.)
            registers[process.Instruction[3]] = process.Instruction[1];

            return registers;
        }

        public static int[] Gtir(int[] registers, InstructionTest process)
        {
            // gtir (greater-than immediate/register) sets register C to 1 if value A is greater than register B. Otherwise, register C is set to 0.
            if (process.Instruction[1] > registers[process.Instruction[2]])
                registers[process.Instruction[3]] = 1;
            else
                registers[process.Instruction[3]] = 0;

            return registers;
        }

        public static int[] Gtri(int[] registers, InstructionTest process)
        {
            // gtri (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
            if (registers[process.Instruction[1]] > process.Instruction[2])
                registers[process.Instruction[3]] = 1;
            else
                registers[process.Instruction[3]] = 0;

            return registers;
        }

        public static int[] Gtrr(int[] registers, InstructionTest process)
        {
            // gtrr (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.
            if (registers[process.Instruction[1]] > registers[process.Instruction[2]])
                registers[process.Instruction[3]] = 1;
            else
                registers[process.Instruction[3]] = 0;

            return registers;
        }

        public static int[] Eqir(int[] registers, InstructionTest process)
        {
            // eqir (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
            if (process.Instruction[1] == registers[process.Instruction[2]])
                registers[process.Instruction[3]] = 1;
            else
                registers[process.Instruction[3]] = 0;

            return registers;
        }

        public static int[] Eqri(int[] registers, InstructionTest process)
        {
            // eqri (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
            if (registers[process.Instruction[1]] == process.Instruction[2])
                registers[process.Instruction[3]] = 1;
            else
                registers[process.Instruction[3]] = 0;

            return registers;
        }

        public static int[] Eqrr(int[] registers, InstructionTest process)
        {
            // eqrr (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
            if (registers[process.Instruction[1]] == registers[process.Instruction[2]])
                registers[process.Instruction[3]] = 1;
            else
                registers[process.Instruction[3]] = 0;

            return registers;
        }
    }
}
