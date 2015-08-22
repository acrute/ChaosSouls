using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ChaosSouls
{
    public class Class1
    {
        public static System.Timers.Timer CreateTimer(int interval)
        {
            return new System.Timers.Timer(interval)
            {
                AutoReset = true
            };
        }

        public static void Main(string[] args)
        {
            var timer = CreateTimer(50);
            timer.Elapsed += OnTimedEvent;
            timer.Start();

            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }

        public static IEnumerable<DarkSoulsCommand> PossibleCommands = new[] 
        {
            DarkSoulsCommands.Backstep,
            DarkSoulsCommands.GoLeft,
            DarkSoulsCommands.GoRight,
            DarkSoulsCommands.GoForward,
            DarkSoulsCommands.GoBack,
            DarkSoulsCommands.CameraAngleUp,
            DarkSoulsCommands.CameraAngleDown,
            DarkSoulsCommands.CameraAngleLeft,
            DarkSoulsCommands.CameraAngleRight,
            DarkSoulsCommands.EnvironmentInteraction,
            DarkSoulsCommands.SwitchActiveSpell,
            DarkSoulsCommands.SwitchLeftHandEquip,
            DarkSoulsCommands.SwitchRightHandEquip,
            DarkSoulsCommands.SwitchActiveItem,
            DarkSoulsCommands.ToggleLockOn,
            DarkSoulsCommands.GestureMenu,
            DarkSoulsCommands.ToggleWeaponGrip,
            DarkSoulsCommands.RightAttackHeavy,
            DarkSoulsCommands.RightAttackLight,
            DarkSoulsCommands.Parry,
            DarkSoulsCommands.Block,
            DarkSoulsCommands.Confirm,
            DarkSoulsCommands.Cancel,
            DarkSoulsCommands.ToggleMenu,
            DarkSoulsCommands.MenuPageUp,
            DarkSoulsCommands.MenuPageDown,
            DarkSoulsCommands.MenuInfoToggle,
            DarkSoulsCommands.MenuTakeOffEquipment,
            DarkSoulsCommands.UseItem
        };

        private static void OnTimedEvent(object obj, ElapsedEventArgs e)
        {
            var random = new Random();
            var index = random.Next(PossibleCommands.Count());
            var command = PossibleCommands.ElementAt(index);

            DSCommandHandler.HandleDSCommand(command);
        }
    }
}
