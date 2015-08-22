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
            SendKeyPress(command.KeyCode);
        }

        private static void SendKeyPress(ScanCodeShort key)
        {
            INPUT Input = new INPUT();
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = key;
            Input.U.ki.dwFlags = (KEYEVENTF.KEYDOWN | KEYEVENTF.SCANCODE);

            SendInput(1, new[] { Input }, INPUT.Size);

            Thread.Sleep(10);

            INPUT Input2 = new INPUT();
            Input2.type = 1; // 1 = Keyboard Input
            Input2.U.ki.wScan = key;
            Input2.U.ki.dwFlags = (KEYEVENTF.KEYUP | KEYEVENTF.SCANCODE);

            SendInput(1, new[] { Input2 }, INPUT.Size);
        }
    }
}
