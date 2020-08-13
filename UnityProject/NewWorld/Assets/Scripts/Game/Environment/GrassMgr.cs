/************************
	FileName:/Scripts/Game/GrassMgr.cs
	CreateAuthor:neo.xu
	CreateTime:6/15/2020 10:43:12 AM
	Tip:6/15/2020 10:43:12 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


namespace Game.Logic
{
    public class GrassMgr : TMonoSingleton<GrassMgr>
    {
        [SerializeField] GameObject[] objects;
        Vector4[] positions = new Vector4[100];

        [SerializeField] List<Explosion> expolsions;
        Vector4[] explosion_positions = new Vector4[100];
        float[] explosion_ranges = new float[100];
        public float speed;
        // Update is called once per frame
        void Update()
        {

            for (int i = 0; i < objects.Length; i++)
            {
                positions[i] = objects[i].transform.position;
            }
            Shader.SetGlobalFloat("_PositionArray", objects.Length);
            Shader.SetGlobalVectorArray("_Positions", positions);


            for (int i = 0; i < expolsions.Count; i++)
            {
                expolsions[i].Tick(speed);
                if (expolsions[i].range <= 0)
                {
                    expolsions.RemoveAt(i);
                }
                else
                {
                    explosion_positions[i] = expolsions[i].pos;
                    explosion_ranges[i] = expolsions[i].range;
                }
            }

            Shader.SetGlobalFloat("_ExplosionPositionArray", expolsions.Count);
            Shader.SetGlobalVectorArray("_ExplosionPositions", explosion_positions);
            Shader.SetGlobalFloatArray("_ExplosionRange", explosion_ranges);
        }


        public void AddExplosion(Vector3 position, float range)
        {
            Explosion explosion = new Explosion();
            explosion.pos = position;
            explosion.range = range;
            expolsions.Add(explosion);
        }
    }

    [System.Serializable]
    public class Explosion
    {
        public Vector3 pos;
        public float range;

        private float vel;
        public void Tick(float speed)
        {
            range = Mathf.SmoothDamp(range, 0, ref vel, Time.deltaTime, speed);
            //range -= Time.deltaTime * 0.1f;
        }
    }

}