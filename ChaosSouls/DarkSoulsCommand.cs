using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace ChaosSouls
{
    public enum DSCommandType
    {
        Left,
        Right,
        Forward,
        Back,
        Backstep
    }

    public class DarkSoulsCommand
    {
        private DSCommandType _type;
        private VirtualKeyCode _keyCode;

        public DarkSoulsCommand(DSCommandType type, VirtualKeyCode keyCode)
        {
            _type = type;
            _keyCode = keyCode;
        }

        public DSCommandType Type
        {
            get { return _type; }
        }

        public VirtualKeyCode KeyCode
        {
            get { return _keyCode; }
        }
    }

    public static class DarkSoulsCommands 
    {
        public static DarkSoulsCommand GoForward = new DarkSoulsCommand(DSCommandType.Forward, VirtualKeyCode.VK_W);
        public static DarkSoulsCommand GoLeft = new DarkSoulsCommand(DSCommandType.Left, VirtualKeyCode.VK_A);
        public static DarkSoulsCommand GoBack = new DarkSoulsCommand(DSCommandType.Back, VirtualKeyCode.VK_S);
        public static DarkSoulsCommand GoRight = new DarkSoulsCommand(DSCommandType.Right, VirtualKeyCode.VK_D);
        public static DarkSoulsCommand Backstep = new DarkSoulsCommand(DSCommandType.Backstep, VirtualKeyCode.SPACE);
    }

    public static class DSCommandHandler
    {
        public static InputSimulator Simulator = new InputSimulator();

        public static void HandleDSCommand(DarkSoulsCommand command)
        {
            Simulator.Keyboard.KeyPress(command.KeyCode);
        }
    }
}
