
namespace MIPSSimulator.Hardware
{


    public class CPU
    {
        public const int REGBANKSIZE = 32; 
        public const int WORDWIDTH = 32;
        public const int ADDRESSWIDTH = 16;
        public const int MEMORYWORDS = 2 ^ (ADDRESSWIDTH - 2);

        public const int FIRSTADDRESS = 0;
        public const int LASTADDRESS = MEMORYWORDS - 1;

        private int[] _registers;
        private int[] _ram;
        private int[] _rom;

        public const int DEFAULTPROGRAMENTRYPOINT = FIRSTADDRESS; //Dirección predeterminada de la primera instrucción del programa

        //Constantes de acceso a los registros:
        // - Registros estandar:
        public const int ZERO = 0; //Cero
        public const int PC = 1; //Program-conter   
        public const int SP = 2; //Stack-pointer
        public const int RA = 3; //Return-address

        // - Registros de proposito general:
        public const int R0 = 4;
        public const int R1 = 5;
        public const int R2 = 6;
        public const int R3 = 7;
        public const int R4 = 8;
        public const int R5 = 9;
        public const int R6 = 10;
        public const int R7 = 11;
        public const int R8 = 12;
        public const int R9 = 13;
        public const int R10 = 14;
        public const int R11 = 15;
        public const int R12 = 16;
        public const int R13 = 17;
        public const int R14 = 18;
        public const int R15 = 19;

        // - El resto no se utilizan (Por ahora)

        private bool _executing;
        private bool _programLoaded;

        public CPU()
        {
            _registers = new int[REGBANKSIZE];
            _ram = new int[MEMORYWORDS];
            _rom = new int[MEMORYWORDS];

            _setupRegisters();

            _executing = false;
        }

        private void _setupRegisters()
        {
            _registers[ZERO] = 0;
            _registers[PC] = DEFAULTPROGRAMENTRYPOINT;
            _registers[SP] = LASTADDRESS; // La pila avanza de abajo a arriba

            for(int i = R0; i <= R15;++i)
                _registers[i] = 0;
        }

        public bool LoadProgram(int[] program, int entryPoint = DEFAULTPROGRAMENTRYPOINT)
        {
            if (program.Length <= MEMORYWORDS)
            {
                for (int i = 0; i < MEMORYWORDS; ++i)
                    _rom[i] = program[i];

                _registers[PC] = entryPoint;

                _programLoaded = true;
            }
            else
                _programLoaded = false;

            return _programLoaded;
        }

        public 

        private void _executionLoop()
        {

        }
    }
}