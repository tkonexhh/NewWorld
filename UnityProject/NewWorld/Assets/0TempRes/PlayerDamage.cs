/************************
	FileName:/0TempRes/PlayerDamage.cs
	CreateAuthor:neo.xu
	CreateTime:11/24/2020 12:16:04 PM
	Tip:11/24/2020 12:16:04 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    public class PlayerDamage : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.gameObject.GetComponent<PlayerMonoReference>();
            if (player != null)
            {
                player.player.role.controlComponent.GetDamage(10);
            }
        }
    }

}