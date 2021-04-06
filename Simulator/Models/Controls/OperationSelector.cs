using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Models.Commands;


namespace Simulator.Models.Controls
{
    class OperationSelector
    {
        private CommandSet _commandSet;

        public OperationSelector(CommandSet commandSet)
        {
            _commandSet = commandSet;
        }

        short register;
        bool destination;
        short bit;
        short literal;
        short target;

        public void ChooseOperation(short operationCode)
        {
            switch (operationCode)
            {
                //BYTE-ORIENTED FILE REGISTER OPERATIONS

                case short opCodeRange when (0b00_0111_0000_0000 <= opCodeRange && opCodeRange <= 0b00_0111_1111_1111):
                    _commandSet._byteCommands.ADDWF(register, destination);
                    break;

                case short opCodeRange when (0b00_0101_0000_0000 <= opCodeRange && opCodeRange <= 0b00_0101_1111_1111):
                    _commandSet._byteCommands.ANDWF(register, destination);
                    break;

                case short opCodeRange when (0b00_0001_1000_0000 <= opCodeRange && opCodeRange <= 0b00_0001_1111_1111):
                    _commandSet._byteCommands.CLRF(register);
                    break;

                case short opCodeRange when (0b00_0001_0000_0000 <= opCodeRange && opCodeRange <= 0b00_0001_0111_1111):
                    _commandSet._byteCommands.CLRW();
                    break;

                case short opCodeRange when (0b00_1001_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1001_1111_1111):
                    _commandSet._byteCommands.COMF(register, destination);
                    break;

                case short opCodeRange when (0b00_0011_0000_0000 <= opCodeRange && opCodeRange <= 0b00_0011_1111_1111):
                    _commandSet._byteCommands.DECF(register, destination);
                    break;

                case short opCodeRange when (0b00_1011_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1011_1111_1111):
                    _commandSet._byteCommands.DECFSZ(register, destination);
                    break;

                case short opCodeRange when (0b00_1010_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1010_0000_0000):
                    _commandSet._byteCommands.INCF(register, destination);
                    break;

                case short opCodeRange when (0b00_1111_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1111_1111_1111):
                    _commandSet._byteCommands.INCFSZ(register, destination);
                    break;

                case short opCodeRange when (0b00_0100_0000_0000 <= opCodeRange && opCodeRange <= 0b00_0100_1111_1111):
                    _commandSet._byteCommands.IORWF(register, destination);
                    break;

                case short opCodeRange when (0b00_1000_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1000_1111_1111):
                    _commandSet._byteCommands.MOVF(register, destination);
                    break;

                case short opCodeRange when (0b00_0000_1000_0000 <= opCodeRange && opCodeRange <= 0b00_0000_1111_1111):
                    _commandSet._byteCommands.MOVWF(register);
                    break;

                case short opCodeRange when (opCodeRange == 0b00_0000_0000_0000 || opCodeRange == 0b00_0000_0110_0000 || opCodeRange == 0b00_0000_0010_0000 || opCodeRange == 0b00_0000_0100_0000):
                    _commandSet._byteCommands.NOP();
                    break;

                case short opCodeRange when (0b00_1101_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1101_1111_1111):
                    _commandSet._byteCommands.RLF(register, destination);
                    break;

                case short opCodeRange when (0b00_1100_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1100_1111_1111):
                    _commandSet._byteCommands.RRF(register, destination);
                    break;

                case short opCodeRange when (0b00_0010_0000_0000 <= opCodeRange && opCodeRange <= 0b00_0010_1111_1111):
                    _commandSet._byteCommands.SUBWF(register, destination);
                    break;

                case short opCodeRange when (0b00_1110_0000_0000 <= opCodeRange && opCodeRange <= 0b00_1110_1111_1111):
                    _commandSet._byteCommands.SWAPF(register, destination);
                    break;

                case short opCodeRange when (0b00_0110_0000_0000 <= opCodeRange && opCodeRange <= 0b00_0110_1111_1111):
                    _commandSet._byteCommands.XORWF(register, destination);
                    break;

                //BIT-ORIENTED FILE REGISTER OPERATIONS

                case short opCodeRange when (0b01_0000_0000_0000 <= opCodeRange && opCodeRange <= 0b01_0011_1111_1111):
                    _commandSet._bitCommands.BCF(register, bit);
                    break;

                case short opCodeRange when (0b01_0100_0000_0000 <= opCodeRange && opCodeRange <= 0b01_0111_1111_1111):
                    _commandSet._bitCommands.BSF(register, bit);
                    break;

                case short opCodeRange when (0b01_1000_0000_0000 <= opCodeRange && opCodeRange <= 0b01_1011_1111_1111):
                    _commandSet._bitCommands.BTFSC(register, bit);
                    break;

                case short opCodeRange when (0b01_1100_0000_0000 <= opCodeRange && opCodeRange <= 0b01_1111_1111_1111):
                    _commandSet._bitCommands.BTFSS(register, bit);
                    break;

                //LITERAL AND CONTROL OPERATIONS

                case short opCodeRange when (0b11_1110_0000_0000 <= opCodeRange && opCodeRange <= 0b11_1111_1111_1111):
                    _commandSet._literalCommands.ADDLW(literal);
                    break;

                case short opCodeRange when (0b11_1001_0000_0000 <= opCodeRange && opCodeRange <= 0b11_1001_1111_1111):
                    _commandSet._literalCommands.ANDLW(literal);
                    break;

                case short opCodeRange when (0b10_0000_0000_0000 <= opCodeRange && opCodeRange <= 0b10_0111_1111_1111):
                    _commandSet._literalCommands.CALL(target);
                    break;

                case 0b00_0000_0110_0100:
                    _commandSet._literalCommands.CLRWTD();
                    break;

                case short opCodeRange when (0b10_1000_0000_0000 <= opCodeRange && opCodeRange <= 0b10_1111_1111_1111):
                    _commandSet._literalCommands.GOTO(target);
                    break;

                case short opCodeRange when (0b11_1000_0000_0000 <= opCodeRange && opCodeRange <= 0b11_1000_1111_1111):
                    _commandSet._literalCommands.IORLW(literal);
                    break;

                case short opCodeRange when (0b11_0000_0000_0000 <= opCodeRange && opCodeRange <= 0b11_0011_1111_1111):
                    _commandSet._literalCommands.MOVLW(literal);
                    break;

                case 0b00_0000_0000_1001:
                    _commandSet._literalCommands.RETFIE();
                    break;

                case short opCodeRange when (0b11_0100_0000_0000 <= opCodeRange && opCodeRange <= 0b11_0111_1111_1111):
                    _commandSet._literalCommands.RETLW(literal);
                    break;

                case 0b00_0000_0000_1000:
                    _commandSet._literalCommands.RETURN();
                    break;

                case 0b00_0000_0110_0011:
                    _commandSet._literalCommands.SLEEP();
                    break;

                case short opCodeRange when (0b11_1100_0000_0000 <= opCodeRange && opCodeRange <= 0b11_1101_1111_1111):
                    _commandSet._literalCommands.SUBLW(literal);
                    break;

                case short opCodeRange when (0b11_1010_0000_0000 <= opCodeRange && opCodeRange <= 0b11_1010_1111_1111):
                    _commandSet._literalCommands.XORLW(literal);
                    break;
            }
        }
    }
}
