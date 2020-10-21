using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using GFrame;

namespace MightyTerrainMesh
{

    public static class MTMatUtils
    {
        private static void SaveMaterail(string dataName, Terrain t, int matIdx, int layerStart, string shaderName)
        {
            if (matIdx >= t.terrainData.alphamapTextureCount)
                return;

            string mathPath = PathHelper.ABSPath2AssetsPath(string.Format("{0}/{1}/{1}_{2}.mat", MTFileUtils.s_DataPath, dataName, matIdx));
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(mathPath);
            if (mat != null)
                AssetDatabase.DeleteAsset(mathPath);
            //alpha map
            byte[] alphaMapData = t.terrainData.alphamapTextures[matIdx].EncodeToTGA();

            string alphaMapSavePath = string.Format("{0}/{1}/{1}_alpha{2}.tga", MTFileUtils.s_DataPath, dataName, matIdx);
            if (File.Exists(alphaMapSavePath))
                File.Delete(alphaMapSavePath);
            FileStream stream = File.Open(alphaMapSavePath, FileMode.Create);
            stream.Write(alphaMapData, 0, alphaMapData.Length);
            stream.Close();
            AssetDatabase.Refresh();

            string alphaMapPath = PathHelper.ABSPath2AssetsPath(string.Format("{0}/{1}/{1}_alpha{2}.tga", MTFileUtils.s_DataPath, dataName, matIdx));
            //the alpha map texture has to be set to best compression quality, otherwise the black spot may show on the ground
            TextureImporter importer = AssetImporter.GetAtPath(alphaMapPath) as TextureImporter;
            if (importer == null)
            {
                Debug.LogError("export terrain alpha map failed");
                return;
            }
            importer.textureCompression = TextureImporterCompression.Uncompressed;
            importer.textureType = TextureImporterType.Default;
            importer.wrapMode = TextureWrapMode.Clamp;
            importer.filterMode = FilterMode.Point;
            EditorUtility.SetDirty(importer);
            importer.SaveAndReimport();
            Texture2D alphaMap = AssetDatabase.LoadAssetAtPath<Texture2D>(alphaMapPath);
            //
            Material tMat = new Material(Shader.Find(shaderName));
            tMat.SetTexture("_SplatMap", alphaMap);
            if (tMat == null)
            {
                Debug.LogError("export terrain material failed");
                return;
            }

            //TODO 如果是DCC软件导入进来的不采用TerrainLayer的方法
            for (int l = layerStart; l < layerStart + 4 && l < t.terrainData.terrainLayers.Length; ++l)
            {
                int idx = l - layerStart;
                TerrainLayer layer = t.terrainData.terrainLayers[l];

                tMat.SetTexture(string.Format("_Splat{0}", idx), layer.diffuseTexture);
                // tMat.SetTextureOffset(string.Format("_Splat{0}", idx), layer.tileOffset);
                // tMat.SetTextureScale(string.Format("_Splat{0}", idx), tiling);
                tMat.SetTexture(string.Format("_Normal{0}", idx), layer.normalMapTexture);
                // tMat.SetFloat(string.Format("_NormalScale{0}", idx), layer.normalScale);
                // tMat.SetFloat(string.Format("_Metallic{0}", idx), layer.metallic);
                // tMat.SetFloat(string.Format("_Smoothness{0}", idx), layer.smoothness);
            }
            AssetDatabase.CreateAsset(tMat, mathPath);
        }
        public static void SaveMaterials(string dataName, Terrain t)
        {
            if (t.terrainData == null)
            {
                Debug.LogError("terrain data doesn't exist");
                return;
            }
            int matCount = t.terrainData.alphamapTextureCount;

            if (matCount <= 0)
                return;
            //base pass
            //Universal Render Pipeline/Terrain/Lit
            // SaveMaterail(dataName, t, 0, 0, "MT/Standard-BasePass");
            SaveMaterail(dataName, t, 0, 0, Game.Logic.WorldDefine.MaterialShaderName);
            for (int i = 1; i < matCount; ++i)
            {
                SaveMaterail(dataName, t, i, i * 4, "MT/Standard-AddPass");
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
