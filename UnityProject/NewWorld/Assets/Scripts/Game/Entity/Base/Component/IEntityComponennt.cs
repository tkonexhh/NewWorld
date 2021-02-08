/************************
	FileName:/Scripts/Game/Entity/Base/Component/IEntityComponennt.cs
	CreateAuthor:neo.xu
	CreateTime:10/21/2020 5:13:55 PM
	Tip:10/21/2020 5:13:55 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public interface IEntityComponennt
    {
        void Init(Entity ownner);
        void Start();
        void Excute(float dt);
        void FixedExcute(float dt);
        void Destroy();
    }

}