namespace MIPSSimulator.Hardware
{
    public struct TypeRData
    {
        public uint opcode;
        public uint rs;
        public uint rt;
        public uint rd;
        public uint shamt;
        public uint funct;

        public TypeRData(uint instruction)
        {
            opcode = (instruction & MASK_OPCODE) >> 26;
            rs = (instruction & MASK_RS) >> 21;
            rt = (instruction & MASK_RT) >> 16;
            rd = (instruction & MASK_RD) >> 11;
            shamt = (instruction & MASK_SHAMT) >> 6;
            funct = (instruction & MASK_FUNCT);
        }
    }

    public struct TypeIData
    {
        public uint opcode;
        public uint rs;
        public uint rt;
        public uint inmediate;

        public TypeIData(uint instruction)
        {
            opcode = (instruction & MASK_OPCODE) >> 26;
            rs = 
            rt = 
            inmediate = (instruction & MASK_INMEDIATE);
        }
    }

    public struct TypeJData
    {
        public uint opcode;
        public uint address;

        public TypeJData(uint instruction)
        {
            opcode = (instruction & MASK_OPCODE) >> 26;
            address = (instruction & MASK_ADDRESS);
        }
    }



    public abstract class AssamblerCodes
    {
        public static const uint MASK_OPCODE = 0xFC000000;    //11111100000000000000000000000000
        public static const uint MASK_RS = 0x3E000000;        //00000011111000000000000000000000
        public static const uint MASK_RT = 0x001F0000;        //00000000000111110000000000000000
        public static const uint MASK_RD = 0x0000F800;        //00000000000000001111100000000000
        public static const uint MASK_SHAMT = 0x000007C0;     //00000000000000000000011111000000
        public static const uint MASK_FUNCT = 0x0000003F;     //00000000000000000000000000111111
        public static const uint MASK_INMEDIATE = 0x0000FFFF; //00000000000000001111111111111111
        public static const uint MASK_ADDRESS = 0x03FFFFFF;   //00000011111111111111111111111111

        public static uint getOpcode(uint instruction){return (instruction & MASK_OPCODE) >> 26;}
        public static uint getRs(uint instruction){return (instruction & MASK_RS) >> 21;}
        public static uint getRt(uint instruction){return (instruction & MASK_RT) >> 16;}
        public static uint getRd(uint instruction){return (instruction & MASK_RD) >> 11;}
        public static uint getShamt(uint instruction){return (instruction & MASK_SHAMT) >> 6;}
        public static uint getFunct(uint instruction){return (instruction & MASK_FUNCT);}
        public static uint getInmediate(uint instruction){return (instruction & MASK_INMEDIATE);}
        public static uint getAddress(uint instruction){return (instruction & MASK_ADDRESS);}


        public static const uint OPCODE_TYPER_ALL = 0x00;

        public static const uint FUNCT_ADD =        0x00; // add rd rs rt (destiny, op1, op2)
        public static const uint FUNCT_SUB =        0x01; // sub rd rs rt (destiny, op1, op2)
        public static const uint FUNCT_MUL =        0x02; // mul rd rs rt (destiny, op1, op2)
        public static const uint FUNCT_DIV =        0x03; // div rd rs rt (destiny, op1, op2)
        public static const uint FUNCT_AND =        0x04; // and rd rs rt (destiny, op1, op2)
        public static const uint FUNCT_OR  =        0x05; // or rd rs rt  (destiny, op1, op2)
        public static const uint FUNCT_NOT =        0x06; // not rd rs    (destiny, source)
        public static const uint FUNCT_XOR =        0x07; // xor rd rs rt (destiny, op1, op2)
        public static const uint FUNCT_RIGHTSHIFT = 0x08; // rsh rd rs rt (destiny, op1, op2)
        public static const uint FUNCT_LEFTSHIFT  = 0x09; // lsh rd rs rt (destiny, op1, op2)

        public static const uint FUNCT_LOADWORD  =  0x10; // lw rd rs rt (destiny, address, index)
        public static const uint FUNCT_STOREWORD =  0x11; // sw rd rs rt (destiny, address, index)

        public static const uint FUNCT_JUMP     =   0x20; // jmp rd (address)
        public static const uint FUNCT_JUMPLINK =   0x21; // jl rd (address)


        public static const uint OPCODE_TYPEI_ADDINMEDIATE = 0x01;        // add rd rs inmediate
        public static const uint OPCODE_TYPEI_SUBINMEDIATE = 0x02;        // sub rd rs inmediate
        public static const uint OPCODE_TYPEI_MULINMEDIATE = 0x03;        // mul rd rs inmediate
        public static const uint OPCODE_TYPEI_DIVINMEDIATE = 0x04;        // div rd rs inmediate
        public static const uint OPCODE_TYPEI_ANDINMEDIATE = 0x04;        // and rd rs inmediate
        public static const uint OPCODE_TYPEI_ORINMEDIATE  = 0x04;        // or rd rs inmediate
        public static const uint OPCODE_TYPEI_XORINMEDIATE = 0x04;        // xor rd rs inmediate
        public static const uint OPCODE_TYPEI_RIGHTSHIFTINMEDIATE = 0x04; // rsh rd rs inmediate
        public static const uint OPCODE_TYPEI_LEFTSHIFTINMEDIATE  = 0x04; // lsh rd rs inmediate

        public static const uint OPCODE_TYPEI_LOADWORDINMEDIATE   = 0x10; // lw rd rs inmediate
        public static const uint OPCODE_TYPEI_STOREWORDINMEDIATE  = 0x11; // sw rd rs inmediate


        public static const uint OPCODE_TYPEJ_JUMP     = 0x20; // jmp inmediate
        public static const uint OPCODE_TYPEJ_JUMPLINK = 0x20; // jl inmediate


        public static const uint FIRST_OPCODE_TYPEI = OPCODE_TYPEI_ADDINMEDIATE;
        public static const uint LAST_OPCODE_TYPEI = OPCODE_TYPEI_STOREWORDINMEDIATE;

        public static bool opcode_isTypeR(uint opcode) { return opcode == OPCODE_TYPER_ALL; }
        public static bool opcode_isTypeI(uint opcode) { return opcode >= FIRST_OPCODE_TYPEI && opcode <= LAST_OPCODE_TYPEI; }
        public static bool opcode_isTypeJ(uint opcode) { return opcode > LAST_OPCODE_TYPEI; }
        public static bool isTypeR(uint instruction) { return opcode_isTypeR(getOpcode(instruction)); }
        public static bool isTypeI(uint instruction) { return opcode_isTypeI(getOpcode(instruction)); }
        public static bool isTypeJ(uint instruction) { return opcode_isTypeJ(getOpcode(instruction)); }
    }
}