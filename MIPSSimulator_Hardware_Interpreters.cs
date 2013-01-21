
namespace MIPSSimulator.Hardware
{


    public abstract class Interpreter
    {
        public static const uint MASK_OPCODE = 0xFC000000; //11111100000000000000000000000000
        public static const uint NOP = 0;

        private static const uint FUNCT_ADD = 0x20;
        private static const uint FUNCT_SUB = 0x22;
        private static const uint FUNCT_MUL = 0x18; //Modificación, sintaxis del tipo mul rd r2 rt
        private static const uint FUNCT_DIV = 0x1A; //Modificación, sintaxis del tipo div rd r2 rt
        private static const uint FUNCT_AND = 0x1A;
        private static const uint FUNCT_OR = 0x1A;
        private static const uint FUNCT_XOR = 0x1A; 
        private static const uint FUNCT_NOR = 0x1A;

        private static const uint OPCODE_ADDI = 0x08;

        private static const uint OPCODE_LOADWORD = 0x23;
        private static const uint OPCODE_STOREWORD = 0x2B;


        public static void Execute(int[] RAM, int[] ROM, int[] Registers, uint instruction)
        {
            uint opcode = (instruction & MASK_OPCODE) >> 26;

            if (instruction != NOP)
            {
                if (opcode == (uint)Opcode.TYPER_GENERAL)
                    _execute_typeR(RAM, ROM, Registers, new TypeRData(instruction));
                else if(opcode == (uint)Opcode.TYPEJ_JUMP || opcode == (uint)Opcode.TYPEJ_JUMPLINK)
                    _execute_typeJ(RAM,ROM,Registers,new TypeJData(instruction));
                else
                    _execute_typeI(RAM,ROM,Registers,new TypeIData(instruction));
            }
        }

        private static void _execute_typeR(int[] RAM, int[] ROM, int[] Registers, TypeRData data)
        {
            switch (data.funct)
            {
                case 
            }
        }

        private static void _execute_typeI(int[] RAM, int[] ROM, int[] Registers, TypeIData data)
        {

        }

        private static void _execute_typeJ(int[] RAM, int[] ROM, int[] Registers, TypeJData data)
        {

        }
    }

    public class TypeRInterpreter : Interpreter
    {

    }
}
