using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosSouls
{
    public static class Chaos
    {
        private static System.Timers.Timer ChaosTimer;

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

        private static System.Timers.Timer CreateTimer(int interval)
        {
            return new System.Timers.Timer(interval)
            {
                AutoReset = true
            };
        }

        public static void Incite()
        {
            ChaosTimer = CreateTimer(50);
            ChaosTimer.Elapsed += OnTimedEvent;
            ChaosTimer.Start();
        }

        // This train we're on don't make no stops
        //public static void Suppress()
        //{
        //    ChaosTimer.Stop();
        //    ChaosTimer.Dispose();
        //}

        private static void OnTimedEvent(object obj, System.Timers.ElapsedEventArgs e)
        {
            var random = new Random();
            var index = random.Next(PossibleCommands.Count());
            var command = PossibleCommands.ElementAt(index);

            DSCommandHandler.HandleDSCommand(command);
        }
    }
}
