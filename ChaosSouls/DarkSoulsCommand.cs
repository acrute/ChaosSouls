using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        Backstep,
        CameraAngleUp,
        CameraAngleDown,
        CameraAngleLeft,
        CameraAngleRight,
        EnvironmentInteraction,
        SwitchActiveSpell,
        SwitchLeftHandEquip,
        SwitchRightHandEquip,
        SwitchActiveItem,
        UseItem,
        ToggleLockOn,
        GestureMenu,
        ToggleWeaponGrip,
        RightAttackHeavy,
        RightAttackLight,
        Parry,
        Block,
        Confirm,
        Cancel,
        ToggleMenu,
        MenuPageUp,
        MenuPageDown,
        MenuInfoToggle,
        MenuTakeOffEquipment
    }

    public class DarkSoulsCommand
    {
        private DSCommandType _type;
        private ScanCodeShort _keyCode;

        public DarkSoulsCommand(DSCommandType type, ScanCodeShort keyCode)
        {
            _type = type;
            _keyCode = keyCode;
        }

        public DSCommandType Type
        {
            get { return _type; }
        }

        public ScanCodeShort KeyCode
        {
            get { return _keyCode; }
        }
    }

    public static class DarkSoulsCommands 
    {
        // Move Around
        public static DarkSoulsCommand GoForward = new DarkSoulsCommand(DSCommandType.Forward, ScanCodeShort.KEY_W);
        public static DarkSoulsCommand GoLeft = new DarkSoulsCommand(DSCommandType.Left, ScanCodeShort.KEY_A);
        public static DarkSoulsCommand GoBack = new DarkSoulsCommand(DSCommandType.Back, ScanCodeShort.KEY_S);
        public static DarkSoulsCommand GoRight = new DarkSoulsCommand(DSCommandType.Right, ScanCodeShort.KEY_D);
        public static DarkSoulsCommand Backstep = new DarkSoulsCommand(DSCommandType.Backstep, ScanCodeShort.SPACE);

        // Camera Controls
        public static DarkSoulsCommand CameraAngleUp = new DarkSoulsCommand(DSCommandType.CameraAngleUp, ScanCodeShort.KEY_I);
        public static DarkSoulsCommand CameraAngleDown = new DarkSoulsCommand(DSCommandType.CameraAngleDown, ScanCodeShort.KEY_K);
        public static DarkSoulsCommand CameraAngleLeft = new DarkSoulsCommand(DSCommandType.CameraAngleLeft, ScanCodeShort.KEY_J);
        public static DarkSoulsCommand CameraAngleRight = new DarkSoulsCommand(DSCommandType.CameraAngleRight, ScanCodeShort.KEY_L);

        // Interact with stuff (or don't)
        public static DarkSoulsCommand EnvironmentInteraction = new DarkSoulsCommand(DSCommandType.EnvironmentInteraction, ScanCodeShort.KEY_Q);
        public static DarkSoulsCommand Confirm = new DarkSoulsCommand(DSCommandType.EnvironmentInteraction, ScanCodeShort.RETURN);
        public static DarkSoulsCommand Cancel = new DarkSoulsCommand(DSCommandType.EnvironmentInteraction, ScanCodeShort.BACK);

        // Fool around in the menu
        public static DarkSoulsCommand GestureMenu = new DarkSoulsCommand(DSCommandType.GestureMenu, ScanCodeShort.KEY_G);
        public static DarkSoulsCommand ToggleMenu = new DarkSoulsCommand(DSCommandType.ToggleMenu, ScanCodeShort.END);
        public static DarkSoulsCommand MenuPageUp = new DarkSoulsCommand(DSCommandType.MenuPageUp, ScanCodeShort.PRIOR); // IS THIS RIGHT??! 
        public static DarkSoulsCommand MenuPageDown = new DarkSoulsCommand(DSCommandType.MenuPageDown, ScanCodeShort.NEXT); 
        public static DarkSoulsCommand MenuInfoToggle = new DarkSoulsCommand(DSCommandType.MenuInfoToggle, ScanCodeShort.INSERT);
        public static DarkSoulsCommand MenuTakeOffEquipment = new DarkSoulsCommand(DSCommandType.MenuTakeOffEquipment, ScanCodeShort.DELETE);

        // Mess with your equipment
        public static DarkSoulsCommand SwitchActiveSpell = new DarkSoulsCommand(DSCommandType.SwitchActiveSpell, ScanCodeShort.KEY_R);
        public static DarkSoulsCommand SwitchActiveItem = new DarkSoulsCommand(DSCommandType.SwitchActiveItem, ScanCodeShort.KEY_F);
        public static DarkSoulsCommand SwitchLeftHandEquip = new DarkSoulsCommand(DSCommandType.SwitchLeftHandEquip, ScanCodeShort.KEY_C);
        public static DarkSoulsCommand SwitchRightHandEquip = new DarkSoulsCommand(DSCommandType.SwitchRightHandEquip, ScanCodeShort.KEY_V);
        public static DarkSoulsCommand UseItem = new DarkSoulsCommand(DSCommandType.UseItem, ScanCodeShort.KEY_E);
        public static DarkSoulsCommand ToggleWeaponGrip = new DarkSoulsCommand(DSCommandType.ToggleWeaponGrip, ScanCodeShort.LMENU); // IS THIS RIGHT??!

        // Get angry and fight people
        public static DarkSoulsCommand ToggleLockOn = new DarkSoulsCommand(DSCommandType.ToggleLockOn, ScanCodeShort.KEY_O);
        public static DarkSoulsCommand RightAttackHeavy = new DarkSoulsCommand(DSCommandType.RightAttackHeavy, ScanCodeShort.KEY_U);
        public static DarkSoulsCommand RightAttackLight = new DarkSoulsCommand(DSCommandType.RightAttackLight, ScanCodeShort.KEY_H);
        public static DarkSoulsCommand Parry = new DarkSoulsCommand(DSCommandType.Parry, ScanCodeShort.TAB);
        public static DarkSoulsCommand Block = new DarkSoulsCommand(DSCommandType.Block, ScanCodeShort.LSHIFT);
    }

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

        public static void SendSingleKey(ScanCodeShort key)
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

        public static void HandleDSCommand(DarkSoulsCommand command)
        {
            SendSingleKey(command.KeyCode);
        }
    }
}
