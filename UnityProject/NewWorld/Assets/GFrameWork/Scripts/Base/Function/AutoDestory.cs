/************************
	FileName:/GFrameWork/Scripts/Base/Function/AutoDestory.cs
	CreateAuthor:neo.xu
	CreateTime:6/12/2020 4:02:29 PM
	Tip:6/12/2020 4:02:30 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class AutoDestory : MonoBehaviour
    {
        public float time = 2.0f;
        private float m_Timer;

        void Update()
        {
            m_Timer += Time.deltaTime;
            if (m_Timer > time)
            {
                Destroy(gameObject);
            }
        }
    }

}