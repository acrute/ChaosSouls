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
        public static bool IsExtendedKey(ScanCodeShort keyCode)
        {
            var extendedKeys = new[] 
            {
                ScanCodeShort.END,
                ScanCodeShort.PRIOR,
                ScanCodeShort.NEXT,
                ScanCodeShort.INSERT,
                ScanCodeShort.DELETE,
                ScanCodeShort.UP,
                ScanCodeShort.DOWN,
                ScanCodeShort.LEFT,
                ScanCodeShort.RIGHT
            };

            return extendedKeys.Any(c => c == keyCode);
        }

        public static void SendKeyDown(ScanCodeShort key)
        {
            INPUT Input = new INPUT();
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = key;
            if (IsExtendedKey(key))
            {
                Input.U.ki.dwFlags = (KEYEVENTF.KEYDOWN | KEYEVENTF.SCANCODE | KEYEVENTF.EXTENDEDKEY);
            }
            else
            {
                Input.U.ki.dwFlags = (KEYEVENTF.KEYDOWN | KEYEVENTF.SCANCODE);
            }
            

            WindowsApi.SendInput(1, new[] { Input }, INPUT.Size);
        }

        public static void SendKeyUp(ScanCodeShort key)
        {
            INPUT Input = new INPUT();
            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = key;
            if (IsExtendedKey(key))
            {
                Input.U.ki.dwFlags = (KEYEVENTF.KEYUP | KEYEVENTF.SCANCODE | KEYEVENTF.EXTENDEDKEY);
            }
            else
            {
                Input.U.ki.dwFlags = (KEYEVENTF.KEYUP| KEYEVENTF.SCANCODE);
            }

            WindowsApi.SendInput(1, new[] { Input }, INPUT.Size);
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
