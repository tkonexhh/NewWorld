/************************
	FileName:/Scripts/Game/Effect/Scan.cs
	CreateAuthor:neo.xu
	CreateTime:1/20/2021 3:14:10 PM
	Tip:1/20/2021 3:14:10 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Logic
{
    [RequireComponent(typeof(Camera))]
    public class PostEffect : MonoBehaviour
    {
        [SerializeField] private Material m_Mat;
        private Camera m_Camera;
        Matrix4x4 farFarClipPos;
        public float scanSpeed = 10;
        public float scanTimer = 0;

        private Vector3 ScanPoint = Vector3.zero;
        private float m_MaxRange;


        private void Awake()
        {
            m_Camera = GetComponent<Camera>();
            scanTimer = m_MaxRange = m_Mat.GetFloat("_MaxRange");
        }

        private void Update()
        {
            if (m_Mat == null)
                return;

            //计算远平面 这里先只处理透视相机
            float fov = m_Camera.fieldOfView;
            float near = m_Camera.nearClipPlane;
            float far = m_Camera.farClipPlane;
            float aspect = m_Camera.aspect;//视锥宽高比

            float halfHeight = far * Mathf.Tan(fov * 0.5f * Mathf.Deg2Rad);
            float halfWidth = halfHeight * aspect;
            Vector3 toRight = halfWidth * m_Camera.transform.right;
            Vector3 toTop = halfHeight * m_Camera.transform.up;


            Vector3 farCenter = m_Camera.transform.forward * far;
            Vector3 farTopLeft = farCenter + toTop - toRight;
            Vector3 farTopRight = farCenter + toTop + toRight;
            Vector3 farBottomLeft = farCenter - toTop - toRight;
            Vector3 farBottomRight = farCenter - toTop + toRight;

            farFarClipPos.SetRow(0, farBottomLeft);
            farFarClipPos.SetRow(1, farBottomRight);
            farFarClipPos.SetRow(2, farTopRight);
            farFarClipPos.SetRow(3, farTopLeft);

            m_Mat.SetMatrix("_FarClipRay", farFarClipPos);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
            {
                scanTimer = 0;
                ScanPoint = hit.point;
            }
            m_Mat.SetVector("_ScanCenter", ScanPoint);

            scanTimer += Time.deltaTime * scanSpeed;
            scanTimer = Mathf.Min(m_MaxRange, scanTimer);


            m_Mat.SetFloat("_ScanRange", scanTimer);
            m_Mat.SetMatrix("_CameraToWorld", m_Camera.cameraToWorldMatrix);

        }

        public void StartScan()
        {
            scanTimer = 0;
        }


        public void SetCenter(Vector3 center)
        {
            ScanPoint = center;
            m_Mat.SetVector("_ScanCenter", ScanPoint);
        }
    }

}