/************************
	FileName:/Scripts/Game/Interactable/IInteractable.cs
	CreateAuthor:neo.xu
	CreateTime:11/27/2020 4:38:59 PM
	Tip:11/27/2020 4:38:59 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IInteractable
    {
        void Interact(Role role);
        void InteractOver(Role role);
    }

}