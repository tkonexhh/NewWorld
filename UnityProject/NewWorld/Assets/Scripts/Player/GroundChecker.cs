/************************
	FileName:/Scripts/Player/GroundChecker.cs
	CreateAuthor:neo.xu
	CreateTime:6/11/2020 9:50:57 AM
	Tip:6/11/2020 9:50:57 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameWish.Game
{
    public class GroundChecker : MonoBehaviour
    {
        public float length = 2;
        public Color lineColor = Color.red;
        public bool isGround = false;

        const float k_GroundRayDistance = 0.7f;

        private void FixedUpdate()
        {
            //Debug.DrawRay(transform.position + Vector3.up * k_GroundRayDistance * 0.5f, -Vector3.up, lineColor);
            RaycastHit hit;
            Ray ray = new Ray(transform.position + Vector3.up * k_GroundRayDistance * 0.5f, -Vector3.up);
            isGround = Physics.Raycast(ray, out hit, k_GroundRayDistance, Physics.AllLayers, QueryTriggerInteraction.Ignore);

        }
    }

}