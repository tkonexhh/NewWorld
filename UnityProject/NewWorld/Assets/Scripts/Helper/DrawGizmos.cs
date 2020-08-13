/************************
	FileName:/Scripts/DrawGizmos.cs
	CreateAuthor:neo.xu
	CreateTime:6/8/2020 11:02:39 AM
	Tip:6/8/2020 11:02:39 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    [ExecuteInEditMode]
    public class DrawGizmos : MonoBehaviour
    {
        public Mesh mesh;
        public Color color;
        public float size = 0.3f;


        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawMesh(mesh, transform.position, Quaternion.identity, Vector3.one * size);
        }
    }

}