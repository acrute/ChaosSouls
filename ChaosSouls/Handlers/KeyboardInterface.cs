using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChaosSouls.Handlers
{
    public static class KeyboardInterface
    {
        ////<summary>
        ////Declaration of external SendInput method
        ////</summary>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(
            uint nInputs,
            [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
            int cbSize);

        public static void SendKeyDown(ScanCodeShort key)
        {
            INPUT Input = new INPUT();
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = key;
            Input.U.ki.dwFlags = (KEYEVENTF.KEYDOWN | KEYEVENTF.SCANCODE);

            SendInput(1, new[] { Input }, INPUT.Size);
        }

        public static void SendKeyUp(ScanCodeShort key)
        {
            INPUT Input2 = new INPUT();
            Input2.type = 1; // 1 = Keyboard Input
            Input2.U.ki.wScan = key;
            Input2.U.ki.dwFlags = (KEYEVENTF.KEYUP | KEYEVENTF.SCANCODE);

            SendInput(1, new[] { Input2 }, INPUT.Size);
        }

        public static void SendKeyPress(ScanCodeShort key)
        {
            SendKeyDown(key);

            Thread.Sleep(10);

            SendKeyUp(key);
        }

        public static void SendKeyChord(params ScanCodeShort[] keys)
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
