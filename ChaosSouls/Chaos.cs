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

        public static IDictionary<string, DSCommandType> CommandMap = new Dictionary<string, DSCommandType>() 
        {
            { "backstep", DSCommandType.Backstep },
            { "roll", DSCommandType.Backstep },

            { "tapleft", DSCommandType.Left },
            { "tapright", DSCommandType.Right },
            { "tapforward", DSCommandType.Forward },
            { "tapback", DSCommandType.Back },

            { "l", DSCommandType.StartMovingLeft },
            { "left", DSCommandType.StartMovingLeft },

            { "r", DSCommandType.StartMovingRight },
            { "right", DSCommandType.StartMovingRight },

            { "f", DSCommandType.StartMovingForward },
            { "forward", DSCommandType.StartMovingForward },
            
            { "b", DSCommandType.StartMovingBack },
            { "back", DSCommandType.StartMovingBack },

            { "fl", DSCommandType.StartMovingForwardLeft },
            { "forwardleft", DSCommandType.StartMovingForwardLeft },
            
            { "fr", DSCommandType.StartMovingForwardLeft },
            { "forwardright", DSCommandType.StartMovingForwardRight },
            
            { "bl", DSCommandType.StartMovingForwardLeft },
            { "backleft", DSCommandType.StartMovingForwardLeft },
            
            { "br", DSCommandType.StartMovingForwardLeft },
            { "backright", DSCommandType.StartMovingForwardLeft },

            { "stop", DSCommandType.StopMoving },

            { "run", DSCommandType.StartRunning },
            { "jog", DSCommandType.StopRunning },

            { "cu", DSCommandType.CameraAngleUp },
            { "cul", DSCommandType.CameraAngleUpLeft },
            { "cur", DSCommandType.CameraAngleUpRight },

            { "cd", DSCommandType.CameraAngleDown },
            { "cdl", DSCommandType.CameraAngleDownLeft },
            { "cdr", DSCommandType.CameraAngleDownRight },

            { "cl", DSCommandType.CameraAngleLeft },
            { "cr", DSCommandType.CameraAngleRight },

            { "a", DSCommandType.EnvironmentInteraction },
            { "du", DSCommandType.SwitchActiveSpell },
            { "dl", DSCommandType.SwitchLeftHandEquip },
            { "dr", DSCommandType.SwitchRightHandEquip },
            { "dd", DSCommandType.SwitchActiveItem },
            { "lock", DSCommandType.ToggleLockOn },
            { "gesture", DSCommandType.GestureMenu },
            { "g", DSCommandType.ToggleWeaponGrip },
            { "r2", DSCommandType.RightAttackHeavy },
            { "r1", DSCommandType.RightAttackLight },
            { "l2", DSCommandType.Parry },
            { "l1", DSCommandType.Block },
            { "block", DSCommandType.Block },
            { "unblock", DSCommandType.StopBlocking },
            { "e", DSCommandType.Confirm },
            { "bs", DSCommandType.Cancel },
            { "m", DSCommandType.ToggleMenu },
            { "pagedn", DSCommandType.MenuPageDown },
            { "pageup", DSCommandType.MenuPageUp },
            { "menuinfo", DSCommandType.MenuInfoToggle },
            { "unequip", DSCommandType.MenuTakeOffEquipment },
            { "ml", DSCommandType.MenuLeft },
            { "mr", DSCommandType.MenuRight },
            { "mu", DSCommandType.MenuUp },
            { "md", DSCommandType.MenuDown},
            { "u", DSCommandType.UseItem },
            { "item", DSCommandType.UseItem },
            { "k", DSCommandType.Kick },
            { "kick", DSCommandType.Kick },
            { "ja", DSCommandType.JumpAttack },
            { "jumpattack", DSCommandType.JumpAttack },
            { "rf", DSCommandType.RollForward },
            { "rb", DSCommandType.RollBack },
            { "rl", DSCommandType.RollLeft },
            { "rr", DSCommandType.RollRight },
            { "combo", DSCommandType.RightAttackLightCombo },
            { "r1x2", DSCommandType.RightAttackLightCombo },
            { "heavycombo", DSCommandType.RightAttackHeavyCombo },
            { "r2x2", DSCommandType.RightAttackHeavyCombo },
        };

        public static ISet<DSCommandType> PossibleCommands = new HashSet<DSCommandType> 
        {
            DSCommandType.Backstep,
            DSCommandType.Left,
            DSCommandType.Right,
            DSCommandType.Forward,
            DSCommandType.Back,

            DSCommandType.CameraAngleUp,
            DSCommandType.CameraAngleUpLeft,
            DSCommandType.CameraAngleUpRight,

            DSCommandType.CameraAngleDown,
            DSCommandType.CameraAngleDownLeft,
            DSCommandType.CameraAngleDownRight,

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
            DSCommandType.UseItem,
            DSCommandType.Kick,
            DSCommandType.RollForward,
            DSCommandType.RollBack,
            DSCommandType.RollLeft,
            DSCommandType.RollRight,
            DSCommandType.JumpAttack,
            DSCommandType.RightAttackHeavyCombo,
            DSCommandType.RightAttackLightCombo,
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
            DSCommandType.StopRunning,

            DSCommandType.ToggleMenu,
            DSCommandType.MenuPageUp,
            DSCommandType.MenuPageDown,
            DSCommandType.MenuInfoToggle,
            DSCommandType.MenuTakeOffEquipment,

            DSCommandType.MenuUp,
            DSCommandType.MenuDown,
            DSCommandType.MenuLeft,
            DSCommandType.MenuRight
        };

        private static System.Timers.Timer CreateTimer(int interval)
        {
            return new System.Timers.Timer(interval)
            {
                AutoReset = true
            };
        }

        public static void StartRandom()
        {
            ChaosTimer = CreateTimer(200);
            ChaosTimer.Elapsed += DispatchRandomChaos;
            ChaosTimer.Start();
        }

        public static void StartRiot()
        {
            ChaosTimer = CreateTimer(500);
            ChaosTimer.Elapsed += DispatchChaosCommand;
            ChaosTimer.Start();
        }

        public static void Dispatch(string command)
        {
            if (CommandMap.ContainsKey(command))
            {
                var commandType = CommandMap[command];
                DSCommandHandler.HandleDSCommand(commandType);
            }
            else
            {
                Console.WriteLine("Unable to handle command {0} - not found", command);
            }
        }

        // This train we're on don't make no stops
        //public static void Suppress()
        //{
        //    ChaosTimer.Stop();
        //    ChaosTimer.Dispose();
        //}

        private static void DispatchChaosCommand(object obj, System.Timers.ElapsedEventArgs e)
        {
            var random = new Random();
            var index = random.Next(CommandMap.Count());
            var kvp = CommandMap.ElementAt(index);
            var command = kvp.Key;

            //Console.WriteLine("Dispatching command {0}", command);

            Dispatch(command);
        }

        private static void DispatchRandomChaos(object obj, System.Timers.ElapsedEventArgs e)
        {
            var random = new Random();
            var index = random.Next(PossibleCommands.Count());
            var commandType = PossibleCommands.ElementAt(index);

            DSCommandHandler.HandleDSCommand(commandType);
        }
    }
}
