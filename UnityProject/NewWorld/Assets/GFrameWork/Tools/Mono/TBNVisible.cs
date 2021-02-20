/************************
	FileName:/GFrameWork/Tools/Mono/TBNVisible.cs
	CreateAuthor:neo.xu
	CreateTime:1/23/2021 2:09:06 PM
	Tip:1/23/2021 2:09:06 PM
************************/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Game.Logic
{
    public class TBNVisible : MonoBehaviour
    {
        public bool ShowT = true;
        public bool ShowB = true;
        public bool ShowN = true;
        [Range(0, 0.5f)] public float lineLength = 0.1f;
        [Range(0, 0.005f)] public float verRadio = 0.001f;


        private void OnDrawGizmos()
        {
            MeshFilter filter = GetComponent<MeshFilter>();
            if (filter == null)
                return;
            Mesh mesh = filter.sharedMesh;
            if (mesh)
            {
                ShowTangent(mesh);
            }
        }

        private void ShowTangent(Mesh mesh)
        {
            var vertices = mesh.vertices;
            var normals = mesh.normals;
            var tangents = mesh.tangents;

            for (int i = 0; i < vertices.Length; i++)
            {
                var verWS = transform.TransformPoint(vertices[i]);
                var normalWS = transform.TransformDirection(normals[i]);
                var tangentWS = transform.TransformDirection(tangents[i]);

                //Normal
                if (ShowN)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(verWS, verWS + normalWS * lineLength);
                }


                //tangentWS
                //因为垂直于法线方向的切线有无数条，所以就用了w来确定到底使用哪一条切线
                if (ShowT)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(verWS, verWS + tangentWS * lineLength);
                }

                //tangentWS 正确方向
                // Gizmos.color = Color.blue;
                float tangetDir = tangents[i].w;
                // Gizmos.DrawLine(verWS, verWS + tangentWS * lineLength);

                //BiTangent 副切线
                if (ShowB)
                {
                    Vector3 biTangentDir = Vector3.Cross(normalWS, tangentWS) * tangetDir;
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawLine(verWS, verWS + biTangentDir * lineLength);
                }

                Gizmos.color = Color.black;
                Gizmos.DrawSphere(verWS, verRadio);
            }
        }
    }

}