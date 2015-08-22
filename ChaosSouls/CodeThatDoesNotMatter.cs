using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosSouls
{
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Text;
    //using System.Threading.Tasks;
    //using System.Runtime.InteropServices;
    ////using Microsoft.DirectX.DirectInput;
    //using System.Windows.Forms;
    //using SharpDX;
    //using SharpDX.DirectInput;
    //using HWND = System.IntPtr;

    //namespace ChaosSouls
    //{
    //    enum SendInputFlags
    //    {
    //        KEYEVENTF_EXTENDEDKEY = 0x0001,
    //        KEYEVENTF_KEYUP = 0x0002,
    //        KEYEVENTF_UNICODE = 0x0004,
    //        KEYEVENTF_SCANCODE = 0x0008,
    //    }

    //    enum KeyboardFlags
    //    {
    //        ExtendedKey = 0x0001,
    //        KeyUp = 0x0002,
    //        Unicode = 0x0004,
    //        ScanCode = 0x0008,
    //    }

    //    struct INPUT
    //    {
    //        public UInt32 type;
    //        public ushort wVk;
    //        public ushort wScan;
    //        public UInt32 dwFlags;
    //        public UInt32 time;
    //        public UIntPtr dwExtraInfo;
    //        public UInt32 uMsg;
    //        public ushort wParamL;
    //        public ushort wParamH;
    //    }

    //    class Program
    //    {
    //        /// filter function
    //        public delegate bool EnumDelegate(IntPtr hWnd, int lParam);

    //        /// check if windows visible
    //        [DllImport("user32.dll")]
    //        [return: MarshalAs(UnmanagedType.Bool)]
    //        public static extern bool IsWindowVisible(IntPtr hWnd);

    //        /// return windows text
    //        [DllImport("user32.dll", EntryPoint = "GetWindowText",
    //        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
    //        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpWindowText, int nMaxCount);

    //        /// enumerator on all desktop windows
    //        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
    //        ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
    //        public static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

    //        [DllImport("user32.dll")]
    //        static extern UInt32 SendInput(UInt32 nInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] INPUT[] pInputs, Int32 cbSize);

    //        [DllImport("user32.dll")]
    //        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    //        [DllImport("user32.dll")]
    //        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    //        [DllImport("user32.dll")]
    //        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    //        // Activate an application window.
    //        [DllImport("user32.dll")]
    //        public static extern bool SetForegroundWindow(IntPtr hWnd);

    //        //[return: MarshalAs(UnmanagedType.Bool)]
    //        //[DllImport("user32.dll", SetLastError = true)]
    //        //public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);

    //        public static void SendLine(IntPtr windowHandle, string line)
    //        {
    //            SetForegroundWindow(windowHandle);

    //            SendKeys.SendWait(line);
    //            SendKeys.SendWait("\n");
    //        }

    //        // You can use tools such as Spy++ to obtain information about the window like its name
    //        // If you leave the first parameter null, then the second param will represent its actual user-visible name
    //        // Such as "Calculator" or "Wordpad"
    //        // It's generally better to use the first param, though, for exact-ness
    //        public static void SendKeysToWindow(string windowName, params string[] inputs)
    //        {
    //            IntPtr windowHandle = FindWindow(null, windowName);

    //            // Verify that the selected process is actually running
    //            if (windowHandle == IntPtr.Zero)
    //            {
    //                Console.WriteLine("Chosen process is not running.");
    //                return;
    //            }

    //            foreach (var input in inputs)
    //            {
    //                SendLine(windowHandle, input);
    //            }
    //        }

    //        public static void Test_SendKeys()
    //        {
    //            var windowName = "Document - WordPad";

    //            SendKeysToWindow(windowName, "Hello!", "OH HAI", "Goodbye!");
    //        }

    //        public static void Test_KeyDown()
    //        {
    //            //INPUT[] InputData = new INPUT[2];
    //            //Key ScanCode = Microsoft.DirectX.DirectInput.Key.W;

    //            //InputData[0].type = 1; //INPUT_KEYBOARD
    //            //InputData[0].wScan = (ushort)ScanCode;
    //            //InputData[0].dwFlags = (uint)SendInputFlags.KEYEVENTF_SCANCODE;

    //            //InputData[1].type = 1; //INPUT_KEYBOARD
    //            //InputData[1].wScan = (ushort)ScanCode;
    //            //InputData[1].dwFlags = (uint)(SendInputFlags.KEYEVENTF_KEYUP | SendInputFlags.KEYEVENTF_UNICODE);

    //            //// send keydown
    //            //if (SendInput(2, InputData, Marshal.SizeOf(InputData[1])) == 0)
    //            //{
    //            //    System.Diagnostics.Debug.WriteLine("SendInput failed with code: " +
    //            //    Marshal.GetLastWin32Error().ToString());
    //            //}

    //            // ---

    //            //INPUT[] KeyUpData = new INPUT[1];

    //            //KeyUpData[0].type = 1;
    //            ////InputData[0].Vk = (ushort)DirectInputKeyScanCode;  //Virtual key is ignored when sending scan code
    //            //KeyUpData[0].wScan = (ushort)DirectInputKeyScanCode;
    //            //KeyUpData[0].dwFlags = (uint)KeyboardFlag.KEYUP | (uint)KeyboardFlag.SCANCODE;
    //            //KeyUpData[0].time = 0;
    //            //KeyUpData[0].dwExtraInfo = UIntPtr.Zero;

    //            //// Send Keyup flag "OR"ed with Scancode flag for keyup to work properly
    //            //SendInput(1, InputData, Marshal.SizeOf(typeof(INPUT)))
    //        }

    //        public static IEnumerable<string> GetAllWindowNames()
    //        {
    //            var collection = new List<string>();
    //            EnumDelegate filter = delegate(IntPtr hWnd, int lParam)
    //            {
    //                StringBuilder strbTitle = new StringBuilder(255);
    //                int nLength = GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
    //                string strTitle = strbTitle.ToString();

    //                if (IsWindowVisible(hWnd) && string.IsNullOrEmpty(strTitle) == false)
    //                {
    //                    collection.Add(strTitle);
    //                }
    //                return true;
    //            };

    //            if (EnumDesktopWindows(IntPtr.Zero, filter, IntPtr.Zero))
    //            {
    //                return collection;
    //            }

    //            return Enumerable.Empty<String>();
    //        }

    //        public static void PrintAllWindowNames()
    //        {
    //            var allWindowNames = GetAllWindowNames();
    //            foreach (var name in allWindowNames)
    //            {
    //                Console.WriteLine(name);
    //            }
    //        }

    //        public static void Test_SharpDX()
    //        {
    //            var directInput = new DirectInput();
    //            var keyboardDevice = directInput.GetDevices(DeviceType.Keyboard, DeviceEnumerationFlags.AllDevices)
    //                .FirstOrDefault();
    //            if (keyboardDevice == null)
    //            {
    //                Console.WriteLine("We couldn't find a keyboard input!");
    //                return;
    //            }

    //            var keyboardGuid = keyboardDevice.InstanceGuid;
    //            var keyboard = new Keyboard(directInput);

    //            keyboard.Properties.BufferSize = 128;
    //            keyboard.Acquire();

    //            while (true)
    //            {
    //                keyboard.Poll();
    //                var datas = keyboard.GetBufferedData();
    //                foreach (var state in datas)
    //                {
    //                    Console.WriteLine(state);
    //                }
    //            }
    //        }

    //        static void Main(string[] args)
    //        {
    //            //PrintAllWindowNames();

    //            //Test_SendKeys();
    //            //Test_SharpDX();
    //        }
    //    }
    //}


    class CodeThatDoesNotMatter
    {
    }
}
