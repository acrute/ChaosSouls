using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        MenuTakeOffEquipment,
        Kick,
        RollForward,
        RollBack,
        RollLeft,
        RollRight
    }
}
