using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChaosSouls.Handlers;

namespace ChaosSouls
{
    public static class DSCommandHandler
    {
        private static IDictionary<DSCommandType, ICommandHandler> CommandMap = new Dictionary<DSCommandType, ICommandHandler>() 
        {
            { DSCommandType.Left, new SingleKeyCommandHandler(ScanCodeShort.KEY_A) },
            { DSCommandType.Right, new SingleKeyCommandHandler(ScanCodeShort.KEY_D) },
            { DSCommandType.Forward, new SingleKeyCommandHandler(ScanCodeShort.KEY_W) },
            { DSCommandType.Back, new SingleKeyCommandHandler(ScanCodeShort.KEY_S) },

            { DSCommandType.ForwardLeft, new KeyChordCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A) },
            { DSCommandType.ForwardRight, new KeyChordCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_D) },
            { DSCommandType.BackLeft, new KeyChordCommandHandler(ScanCodeShort.KEY_S, ScanCodeShort.KEY_A) },
            { DSCommandType.BackRight, new KeyChordCommandHandler(ScanCodeShort.KEY_S, ScanCodeShort.KEY_D) },
            
            { DSCommandType.Backstep, new SingleKeyCommandHandler(ScanCodeShort.SPACE) },
            { DSCommandType.CameraAngleUp, new SingleKeyCommandHandler(ScanCodeShort.KEY_I) },
            { DSCommandType.CameraAngleDown, new SingleKeyCommandHandler(ScanCodeShort.KEY_K) },
            { DSCommandType.CameraAngleLeft, new SingleKeyCommandHandler(ScanCodeShort.KEY_J) },
            { DSCommandType.CameraAngleRight, new SingleKeyCommandHandler(ScanCodeShort.KEY_L) },
            { DSCommandType.EnvironmentInteraction, new SingleKeyCommandHandler(ScanCodeShort.KEY_Q) },
            { DSCommandType.SwitchActiveSpell, new SingleKeyCommandHandler(ScanCodeShort.KEY_R) },
            { DSCommandType.SwitchLeftHandEquip, new SingleKeyCommandHandler(ScanCodeShort.KEY_C) },
            { DSCommandType.SwitchRightHandEquip, new SingleKeyCommandHandler(ScanCodeShort.KEY_V) },
            { DSCommandType.SwitchActiveItem, new SingleKeyCommandHandler(ScanCodeShort.KEY_F) },
            { DSCommandType.UseItem, new SingleKeyCommandHandler(ScanCodeShort.KEY_E) },
            { DSCommandType.ToggleLockOn, new SingleKeyCommandHandler(ScanCodeShort.KEY_O) },
            { DSCommandType.GestureMenu, new SingleKeyCommandHandler(ScanCodeShort.KEY_G) },

            { DSCommandType.ToggleWeaponGrip, new SingleKeyCommandHandler(ScanCodeShort.LMENU) }, // This is questionable
            { DSCommandType.RightAttackHeavy, new SingleKeyCommandHandler(ScanCodeShort.KEY_U) },
            { DSCommandType.RightAttackLight, new SingleKeyCommandHandler(ScanCodeShort.KEY_H) },
            { DSCommandType.Parry, new SingleKeyCommandHandler(ScanCodeShort.TAB) },
            { DSCommandType.Block, new SingleKeyCommandHandler(ScanCodeShort.LSHIFT) },
            { DSCommandType.Confirm, new SingleKeyCommandHandler(ScanCodeShort.RETURN) },
            { DSCommandType.Cancel, new SingleKeyCommandHandler(ScanCodeShort.BACK) }, // A little questionable

            { DSCommandType.ToggleMenu, new SingleKeyCommandHandler(ScanCodeShort.END) },
            { DSCommandType.MenuPageUp, new SingleKeyCommandHandler(ScanCodeShort.PRIOR) }, // Really questionable
            { DSCommandType.MenuPageDown, new SingleKeyCommandHandler(ScanCodeShort.NEXT) }, // Really questionable
            { DSCommandType.MenuInfoToggle, new SingleKeyCommandHandler(ScanCodeShort.INSERT) },
            { DSCommandType.MenuTakeOffEquipment, new SingleKeyCommandHandler(ScanCodeShort.DELETE) },

            // Complex Commands...

            { DSCommandType.Kick, new KeyChordCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_H) },
            { DSCommandType.RollForward, new KeyChordCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.SPACE) },
            { DSCommandType.RollBack, new KeyChordCommandHandler(ScanCodeShort.KEY_S, ScanCodeShort.SPACE) },
            { DSCommandType.RollLeft, new KeyChordCommandHandler(ScanCodeShort.KEY_A, ScanCodeShort.SPACE) },
            { DSCommandType.RollRight, new KeyChordCommandHandler(ScanCodeShort.KEY_D, ScanCodeShort.SPACE) },
            { DSCommandType.JumpAttack, new KeyChordCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_U) },

            { DSCommandType.RightAttackHeavyCombo, new DelayedKeyCommandHandler(630, ScanCodeShort.KEY_U, ScanCodeShort.KEY_U) },
            { DSCommandType.RightAttackLightCombo, new DelayedKeyCommandHandler(630, ScanCodeShort.KEY_H, ScanCodeShort.KEY_H) },
            
            { DSCommandType.StartBlocking, new HoldKeyCommandHandler(ScanCodeShort.LSHIFT) },
            { DSCommandType.StopBlocking, new ReleaseKeyCommandHandler(ScanCodeShort.LSHIFT) },

            { DSCommandType.StartMovingForward, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_W)) },

            { DSCommandType.StartMovingForwardLeft, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A)) },

            { DSCommandType.StartMovingForwardRight, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_D)) },

            { DSCommandType.StartMovingLeft, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_A)) },

            { DSCommandType.StartMovingRight, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_D)) },

            { DSCommandType.StartMovingBack, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_S)) },

            { DSCommandType.StartMovingBackLeft, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_S, ScanCodeShort.KEY_A)) },

            { DSCommandType.StartMovingBackRight, new SequentialCommandHandler(
                new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D),
                new HoldKeyCommandHandler(ScanCodeShort.KEY_S, ScanCodeShort.KEY_D)) },

            { DSCommandType.StopMoving, new ReleaseKeyCommandHandler(ScanCodeShort.KEY_W, ScanCodeShort.KEY_A, ScanCodeShort.KEY_S, ScanCodeShort.KEY_D) },

            { DSCommandType.StartRunning, new HoldKeyCommandHandler(ScanCodeShort.SPACE) },
            { DSCommandType.StopRunning, new ReleaseKeyCommandHandler(ScanCodeShort.SPACE) }
        };

        public static void HandleDSCommand(DSCommandType commandType)
        {
            if (CommandMap.ContainsKey(commandType))
            {
                var handler = CommandMap[commandType];
                handler.Handle();
            }
            else
            {
                Console.WriteLine("Unable to handle command type {0} - no associated handler", commandType);
            }
        }
    }
}
