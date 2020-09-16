﻿namespace MightyTerrainMesh
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    internal class CreateDataJob
    {
        public MTTerrainScanner[] LODs;
        private int curLodIdx = 0;
        public bool IsDone
        {
            get
            {
                return curLodIdx >= LODs.Length;
            }
        }
        public float progress
        {
            get
            {
                if (curLodIdx < LODs.Length)
                {
                    return (curLodIdx + LODs[curLodIdx].progress) / LODs.Length;
                }
                return 1;
            }
        }
        public CreateDataJob(Bounds VolumnBound, int mx, int mz, MTMeshLODSetting[] setting)
        {
            LODs = new MTTerrainScanner[setting.Length];
            for (int i = 0; i < setting.Length; ++i)
            {
                MTMeshLODSetting s = setting[i];
                //only first lod stitch borders, other lod use the most detailed border to avoid 
                //tearing on the border
                LODs[i] = new MTTerrainScanner(VolumnBound, s.Subdivision, s.SlopeAngleError, mx, mz,
                    i == 0);
            }
        }
        public void Update()
        {
            if (LODs == null || IsDone)
                return;
            LODs[curLodIdx].Update();
            if (LODs[curLodIdx].IsDone)
                ++curLodIdx;
        }
        public void EndProcess()
        {
            //copy borders
            MTTerrainScanner detail = LODs[0];
            detail.FillData();
            for (int i = 1; i < LODs.Length; ++i)
            {
                MTTerrainScanner scaner = LODs[i];
                for (int t = 0; t < detail.Trees.Length; ++t)
                {
                    SamplerTree dt = detail.Trees[t];
                    SamplerTree lt = scaner.Trees[t];
                    foreach (var b in dt.Boundaries)
                    {
                        lt.Boundaries.Add(b.Key, b.Value);
                    }
                }
                scaner.FillData();
            }
        }
    }

    internal class MTTerrainScanner : ITerrainTreeScaner
    {
        public int maxX { get; private set; }
        public int maxZ { get; private set; }
        public int subdivision { get; private set; }
        public float slopeAngleErr { get; private set; }
        public Vector2 gridSize { get; private set; }
        public SamplerTree[] Trees { get; private set; }
        public Vector3 center { get; private set; }
        private Vector3 vCheckTop = Vector3.one;
        private float CheckRayLen = 0;
        private int curXIdx = 0;
        private int curZIdx = 0;
        private int detailedSize = 1;
        private bool stitchBorder = true;
        public bool IsDone
        {
            get
            {
                return curXIdx >= maxX && curZIdx >= maxZ;
            }
        }
        public float progress
        {
            get
            {
                return (float)(curXIdx + curZIdx * maxX) / (float)(maxX * maxZ);
            }
        }
        public MTTerrainScanner(Bounds VolumnBound, int sub, float angleErr, int mx, int mz, bool sbrd)
        {
            maxX = mx;
            maxZ = mz;
            subdivision = Mathf.Max(1, sub);
            slopeAngleErr = Mathf.Max(0.1f, angleErr);
            stitchBorder = sbrd;
            center = VolumnBound.center;
            gridSize = new Vector2(VolumnBound.size.x / mx, VolumnBound.size.z / mz);
            vCheckTop = new Vector3(VolumnBound.center.x - VolumnBound.size.x / 2,
                 VolumnBound.center.y + VolumnBound.size.y / 2,
                VolumnBound.center.z - VolumnBound.size.z / 2);
            CheckRayLen = VolumnBound.size.y * 1.1f;
            //
            detailedSize = 1 << subdivision;
            //
            Trees = new SamplerTree[maxX * maxZ];
        }
        public SamplerTree GetSubTree(int x, int z)
        {
            if (x < 0 || x >= maxX || z < 0 || z >= maxZ)
                return null;
            return Trees[x * maxZ + z];
        }
        void ITerrainTreeScaner.Run(Vector3 center, out Vector3 hitpos, out Vector3 hitnormal)
        {
            hitpos = center;
            hitnormal = Vector3.up;
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(center, Vector3.down, out hit, CheckRayLen))
            {
                hitpos = hit.point;
                hitnormal = hit.normal;
            }
            else
            {
                Debug.LogError("scan didn't hit terrain");
            }
        }
        private void ScanTree(SamplerTree sampler)
        {
            sampler.RunSampler(this);
            if (!stitchBorder)
                return;
            int detailedX = curXIdx * detailedSize;
            int detailedZ = curZIdx * detailedSize;
            //boundary
            float bfx = curXIdx * gridSize[0];
            float bfz = curZIdx * gridSize[1];
            float borderOffset = 0;
            if (curXIdx == 0 || curZIdx == 0 || curXIdx == maxX - 1 || curZIdx == maxZ - 1)
                borderOffset = 0.01f;
            RayCastBoundary(bfx + borderOffset, bfz + borderOffset,
                detailedX, detailedZ, SamplerTree.LBCorner, sampler);
            RayCastBoundary(bfx + borderOffset, bfz + gridSize[1] - borderOffset,
                detailedX, detailedZ + detailedSize - 1, SamplerTree.LTCorner, sampler);
            RayCastBoundary(bfx + gridSize[0] - borderOffset, bfz + gridSize[1] - borderOffset,
                detailedX + detailedSize - 1, detailedZ + detailedSize - 1, SamplerTree.RTCorner, sampler);
            RayCastBoundary(bfx + gridSize[0] - borderOffset, bfz + borderOffset,
                detailedX + detailedSize - 1, detailedZ, SamplerTree.RBCorner, sampler);
            for (int u = 1; u < detailedSize; ++u)
            {
                float fx = (curXIdx + (float)u / detailedSize) * gridSize[0];
                RayCastBoundary(fx, bfz + borderOffset, u + detailedX, detailedZ, SamplerTree.BBorder, sampler);
                RayCastBoundary(fx, bfz + gridSize[1] - borderOffset,
                    u + detailedX, detailedZ + detailedSize - 1, SamplerTree.TBorder, sampler);
            }
            for (int v = 1; v < detailedSize; ++v)
            {
                float fz = (curZIdx + (float)v / detailedSize) * gridSize[1];
                RayCastBoundary(bfx + borderOffset, fz, detailedX, v + detailedZ, SamplerTree.LBorder, sampler);
                RayCastBoundary(bfx + gridSize[0] - borderOffset, fz,
                    detailedX + detailedSize - 1, v + detailedZ, SamplerTree.RBorder, sampler);
            }
        }
        private void RayCastBoundary(float fx, float fz, int x, int z, byte bk, SamplerTree sampler)
        {
            Vector3 top = vCheckTop + fx * Vector3.right + fz * Vector3.forward;
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(top, Vector3.down, out hit, CheckRayLen))
            {
                SampleVertexData vert = new SampleVertexData();
                vert.Position = hit.point;
                vert.Normal = hit.normal;
                vert.UV = new Vector2(fx / maxX / gridSize[0], fz / maxZ / gridSize[1]);
                sampler.AddBoundary(subdivision, x, z, bk, vert);
            }
            else
            {
                Debug.LogError("RayCastBoundary didn't hit terrain");
            }
        }
        public void Update()
        {
            if (IsDone)
                return;
            float fx = (curXIdx + 0.5f) * gridSize[0];
            float fz = (curZIdx + 0.5f) * gridSize[1];
            Vector3 center = vCheckTop + fx * Vector3.right + fz * Vector3.forward;
            Vector2 uv = new Vector2((curXIdx + 0.5f) / maxX, (curZIdx + 0.5f) / maxZ);
            Vector2 uvstep = new Vector2(1f / maxX, 1f / maxZ);
            if (Trees[curXIdx * maxZ + curZIdx] == null)
                Trees[curXIdx * maxZ + curZIdx] = new SamplerTree(subdivision, center, gridSize, uv, uvstep);
            ScanTree(Trees[curXIdx * maxZ + curZIdx]);
            //update idx
            ++curXIdx;
            if (curXIdx >= maxX)
            {
                if (curZIdx < maxZ - 1)
                    curXIdx = 0;
                ++curZIdx;
            }
        }
        private Vector3 AverageNormal(List<SampleVertexData> lvers)
        {
            Vector3 normal = Vector3.up;
            for (int i = 0; i < lvers.Count; ++i)
            {
                normal += lvers[i].Normal;
            }
            return normal.normalized;
        }
        private void MergeCorners(List<SampleVertexData> l0, List<SampleVertexData> l1, List<SampleVertexData> l2,
            List<SampleVertexData> l3)
        {
            List<SampleVertexData> lvers = new List<SampleVertexData>();
            //lb
            lvers.Add(l0[0]);
            if (l1 != null)
                lvers.Add(l1[0]);
            if (l2 != null)
                lvers.Add(l2[0]);
            if (l3 != null)
                lvers.Add(l3[0]);
            Vector3 normal = AverageNormal(lvers);
            l0[0].Normal = normal;
            if (l1 != null)
                l1[0].Normal = normal;
            if (l2 != null)
                l2[0].Normal = normal;
            if (l3 != null)
                l3[0].Normal = normal;
        }
        private void StitchCorner(int x, int z)
        {
            SamplerTree center = GetSubTree(x, z);
            if (!center.Boundaries.ContainsKey(SamplerTree.LBCorner))
            {
                Debug.LogError("boundary data missing");
                return;
            }
            SamplerTree right = GetSubTree(x + 1, z);
            SamplerTree left = GetSubTree(x - 1, z);
            SamplerTree right_top = GetSubTree(x + 1, z + 1);
            SamplerTree top = GetSubTree(x, z + 1);
            SamplerTree left_top = GetSubTree(x - 1, z + 1);
            SamplerTree left_down = GetSubTree(x - 1, z - 1);
            SamplerTree down = GetSubTree(x, z - 1);
            SamplerTree right_down = GetSubTree(x + 1, z - 1);
            if (!center.StitchedBorders.Contains(SamplerTree.LBCorner))
            {
                MergeCorners(center.Boundaries[SamplerTree.LBCorner],
                    left != null ? left.Boundaries[SamplerTree.RBCorner] : null,
                    left_down != null ? left_down.Boundaries[SamplerTree.RTCorner] : null,
                    down != null ? down.Boundaries[SamplerTree.LTCorner] : null);
                center.StitchedBorders.Add(SamplerTree.LBCorner);
                if (left != null) left.StitchedBorders.Add(SamplerTree.RBCorner);
                if (left_down != null) left_down.StitchedBorders.Add(SamplerTree.RTCorner);
                if (down != null) left.StitchedBorders.Add(SamplerTree.LTCorner);
            }
            if (!center.StitchedBorders.Contains(SamplerTree.RBCorner))
            {
                MergeCorners(center.Boundaries[SamplerTree.RBCorner],
                    right != null ? right.Boundaries[SamplerTree.LBCorner] : null,
                    right_down != null ? right_down.Boundaries[SamplerTree.LTCorner] : null,
                    down != null ? down.Boundaries[SamplerTree.RTCorner] : null);
                center.StitchedBorders.Add(SamplerTree.RBCorner);
                if (right != null) right.StitchedBorders.Add(SamplerTree.LBCorner);
                if (right_down != null) right_down.StitchedBorders.Add(SamplerTree.LTCorner);
                if (down != null) down.StitchedBorders.Add(SamplerTree.RTCorner);
            }
            if (!center.StitchedBorders.Contains(SamplerTree.LTCorner))
            {
                MergeCorners(center.Boundaries[SamplerTree.LTCorner],
                    left != null ? left.Boundaries[SamplerTree.RTCorner] : null,
                    left_top != null ? left_top.Boundaries[SamplerTree.RBCorner] : null,
                    top != null ? top.Boundaries[SamplerTree.LBCorner] : null);
                center.StitchedBorders.Add(SamplerTree.LTCorner);
                if (left != null) left.StitchedBorders.Add(SamplerTree.RTCorner);
                if (left_top != null) left_top.StitchedBorders.Add(SamplerTree.RBCorner);
                if (top != null) top.StitchedBorders.Add(SamplerTree.LBCorner);
            }

            if (!center.StitchedBorders.Contains(SamplerTree.RTCorner))
            {
                MergeCorners(center.Boundaries[SamplerTree.RTCorner],
                    right != null ? right.Boundaries[SamplerTree.LTCorner] : null,
                    right_top != null ? right_top.Boundaries[SamplerTree.LBCorner] : null,
                    top != null ? top.Boundaries[SamplerTree.RBCorner] : null);
                center.StitchedBorders.Add(SamplerTree.RTCorner);
                if (right != null) right.StitchedBorders.Add(SamplerTree.LTCorner);
                if (right_top != null) right_top.StitchedBorders.Add(SamplerTree.LBCorner);
                if (top != null) top.StitchedBorders.Add(SamplerTree.RBCorner);
            }
        }
        public void FillData()
        {
            for (int i = 0; i < Trees.Length; ++i)
            {
                Trees[i].FillData(slopeAngleErr);
            }
            //stitch the border
            float minDis = Mathf.Min(gridSize.x, gridSize.y) / detailedSize / 2f;
            for (int x = 0; x < maxX; ++x)
            {
                for (int z = 0; z < maxZ; ++z)
                {
                    SamplerTree center = GetSubTree(x, z);
                    //corners
                    StitchCorner(x, z);
                    //borders
                    center.StitchBorder(SamplerTree.BBorder, SamplerTree.TBorder, minDis, GetSubTree(x, z - 1));
                    center.StitchBorder(SamplerTree.LBorder, SamplerTree.RBorder, minDis, GetSubTree(x - 1, z));
                    center.StitchBorder(SamplerTree.RBorder, SamplerTree.LBorder, minDis, GetSubTree(x + 1, z));
                    center.StitchBorder(SamplerTree.TBorder, SamplerTree.BBorder, minDis, GetSubTree(x, z + 1));
                }
            }
            //merge boundary with verts for tessallation
            for (int i = 0; i < Trees.Length; ++i)
            {
                foreach (var l in Trees[i].Boundaries.Values)
                    Trees[i].Vertices.AddRange(l);
            }
        }
    }
}
