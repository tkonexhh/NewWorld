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
        public virtual string movement => "Relaxed_Movement_Blend";
        public virtual string death => "Unarmed-Death1";
        public virtual string land => "Land";
        public virtual string fall => "Fall";
        public virtual string hurt => "2Hand-Axe-GetHurtBlend";
        public virtual string roll_Forward => "Staff-Roll-Forward";
        public virtual string roll_Backward => "Staff-Roll-Backward";
        public virtual string roll_Left => "Staff-Roll-Left";
        public virtual string roll_Right => "Staff-Roll-Right";
    }

    public class TowHandAxeAnimName : RoleAnimName
    {
        public override string movement => "2Hand-Axe-Movement-Blend";
        public override string death => "2Hand-Axe-Death1";
        public override string land => "2Hand-Axe-Land";
        public override string fall => "2Hand-Axe-Fall";
        public override string hurt => "2Hand-Axe-GetHurtBlend";
        public override string roll_Forward => "2Hand-Axe-Roll-Forward";
        public override string roll_Backward => "2Hand-Axe-Roll-Backward";
        public override string roll_Left => "2Hand-Axe-Roll-Left";
        public override string roll_Right => "2Hand-Axe-Roll-Right";
    }

}