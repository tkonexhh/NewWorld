/************************
	FileName:/Scripts/Game/Entity/Role/RoleAnimName.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 4:17:45 PM
	Tip:11/24/2020 4:17:45 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class RoleAnimName
    {
        public virtual string idle => "Idle";
        public virtual string movement => "Relaxed_Movement_Blend";
        public virtual string death => "Unarmed-Death1";
        public virtual string revive => "Revive";
        public virtual string jump => "Jump";
        public virtual string jumpFlip => "Jump-Flip";
        public virtual string land => "Land";
        public virtual string fall => "Fall";
        public virtual string hurt => "2Hand-Axe-GetHurtBlend";
        public virtual string roll_Forward => "Staff-Roll-Forward";
        public virtual string roll_Backward => "Staff-Roll-Backward";
        public virtual string roll_Left => "Staff-Roll-Left";
        public virtual string roll_Right => "Staff-Roll-Right";
        public virtual string crouch => "Crouch";
        public virtual string boost => "Boost";

        public string sit = "Sit-Sitdown";
        public string sit_Idle = "Sit-Idle";
        public string sit_StandUp = "Sit-Standup";

        public string sleep = "Sleep-SleepDown";
        public string sleep_Idle = "Sleep-Idle";
        public string sleep_StandUp = "Sleep-Standup";

        public virtual string pickUp => "Pickup";
    }

    public class RoleWeaponAnimName : RoleAnimName
    {

    }

    public class TowHandAxeAnimName : RoleAnimName
    {
        public override string idle => "2Hand-Axe-Idle";
        public override string movement => "2Hand-Axe-Movement-Blend";
        public override string death => "2Hand-Axe-Death1";
        public override string revive => "2Hand-Axe-Revive1";
        public override string jump => "2Hand-Axe-Jump";
        public override string land => "2Hand-Axe-Land";
        public override string fall => "2Hand-Axe-Fall";
        public override string hurt => "2Hand-Axe-GetHurtBlend";
        public override string roll_Forward => "2Hand-Axe-Roll-Forward";
        public override string roll_Backward => "2Hand-Axe-Roll-Backward";
        public override string roll_Left => "2Hand-Axe-Roll-Left";
        public override string roll_Right => "2Hand-Axe-Roll-Right";
        public override string crouch => "2Hand-Axe-Idle-Crouch";
        public override string boost => "2Hand-Axe-Boost";

        public override string pickUp => "2Hand-Axe-Pickup";
    }

}