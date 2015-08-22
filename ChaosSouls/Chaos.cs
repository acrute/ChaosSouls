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

        public static IEnumerable<DSCommandType> PossibleCommands = new[] 
        {
            DSCommandType.Backstep,
            DSCommandType.Left,
            DSCommandType.Right,
            DSCommandType.Forward,
            DSCommandType.Back,
            DSCommandType.CameraAngleUp,
            DSCommandType.CameraAngleDown,
            DSCommandType.CameraAngleLeft,
            DSCommandType.CameraAngleRight,
            DSCommandType.EnvironmentInteraction,
            DSCommandType.SwitchActiveSpell,
            DSCommandType.SwitchLeftHandEquip,
            DSCommandType.SwitchRightHandEquip,
            DSCommandType.SwitchActiveItem,
            DSCommandType.ToggleLockOn,
            DSCommandType.GestureMenu,
            DSCommandType.ToggleWeaponGrip,
            DSCommandType.RightAttackHeavy,
            DSCommandType.RightAttackLight,
            DSCommandType.Parry,
            DSCommandType.Block,
            DSCommandType.Confirm,
            DSCommandType.Cancel,
            DSCommandType.ToggleMenu,
            DSCommandType.MenuPageUp,
            DSCommandType.MenuPageDown,
            DSCommandType.MenuInfoToggle,
            DSCommandType.MenuTakeOffEquipment,
            DSCommandType.UseItem,
            DSCommandType.Kick,
            DSCommandType.RollForward,
            DSCommandType.RollBack,
            DSCommandType.RollLeft,
            DSCommandType.RollRight,
            DSCommandType.JumpAttack,
            DSCommandType.RightAttackHeavyCombo,
            DSCommandType.RightAttackLightCombo,
            DSCommandType.StartBlocking,
            DSCommandType.StopBlocking,

            DSCommandType.StartMovingForward,
            DSCommandType.StartMovingForwardLeft,
            DSCommandType.StartMovingForwardRight,
            DSCommandType.StartMovingBack,
            DSCommandType.StartMovingBackLeft,
            DSCommandType.StartMovingBackRight,
            DSCommandType.StartMovingLeft,
            DSCommandType.StartMovingRight,

            DSCommandType.StopMoving,
            DSCommandType.StartRunning,
            DSCommandType.StopRunning
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
            ChaosTimer = CreateTimer(200);
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
            var commandType = PossibleCommands.ElementAt(index);

            DSCommandHandler.HandleDSCommand(commandType);
        }
    }
}
