using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChaosSouls
{
    public static class DSCommandHandler
    {
        ////<summary>
        ////Declaration of external SendInput method
        ////</summary>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(
            uint nInputs,
            [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
            int cbSize);

        public static void HandleDSCommand(DarkSoulsCommand command)
        {
            if (command.Type == DSCommandType.Kick)
            {
                SendKeyChord(ScanCodeShort.KEY_W, ScanCodeShort.KEY_H);
            }
            else if (command.Type == DSCommandType.RollForward)
            {
                SendKeyChord(ScanCodeShort.KEY_W, ScanCodeShort.SPACE);
            }
            else if (command.Type == DSCommandType.RollBack)
            {
                SendKeyChord(ScanCodeShort.KEY_S, ScanCodeShort.SPACE);
            }
            else if (command.Type == DSCommandType.RollLeft)
            {
                SendKeyChord(ScanCodeShort.KEY_A, ScanCodeShort.SPACE);
            }
            else if (command.Type == DSCommandType.RollRight)
            {
                SendKeyChord(ScanCodeShort.KEY_D, ScanCodeShort.SPACE);
            }
            else
            {
                SendKeyPress(command.KeyCode);
            }
        }

        private static void SendKeyDown(ScanCodeShort key)
        {
            INPUT Input = new INPUT();
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = key;
            Input.U.ki.dwFlags = (KEYEVENTF.KEYDOWN | KEYEVENTF.SCANCODE);

            SendInput(1, new[] { Input }, INPUT.Size);
        }

        private static void SendKeyUp(ScanCodeShort key)
        {
            INPUT Input2 = new INPUT();
            Input2.type = 1; // 1 = Keyboard Input
            Input2.U.ki.wScan = key;
            Input2.U.ki.dwFlags = (KEYEVENTF.KEYUP | KEYEVENTF.SCANCODE);

            SendInput(1, new[] { Input2 }, INPUT.Size);
        }

        private static void SendKeyPress(ScanCodeShort key)
        {
            SendKeyDown(key);

            Thread.Sleep(10);

            SendKeyUp(key);
        }

        private static void SendKeyChord(params ScanCodeShort[] keys)
        {
            Stack<ScanCodeShort> pressedKeys = new Stack<ScanCodeShort>();
            foreach (var key in keys)
            {
                SendKeyDown(key);
                pressedKeys.Push(key);
            }

            Thread.Sleep(10);

            while (pressedKeys.Any())
            {
                var key = pressedKeys.Pop();
                SendKeyUp(key);
            }
        }
    }
}
