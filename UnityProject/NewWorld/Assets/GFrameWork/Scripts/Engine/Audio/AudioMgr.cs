/************************
	FileName:/GFrameWork/Scripts/Engine/Audio/AudioMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 1:33:40 PM
	Tip:7/7/2020 1:33:40 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[AudioMgr]")]
    public class AudioMgr : TMonoSingleton<AudioMgr>
    {
        [Header("Audio control")]
        [SerializeField] private AudioMixer audioMixer = default;
        [SerializeField, Range(0f, 1f)] private float m_MasterVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float m_SoundVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float m_MusicVolume = 1f;

        private const string POOL_NAME = "SoundEmitter";
        public override void OnSingletonInit()
        {
            GameObject prefab = new GameObject("SoundEmitter Prefab");
            prefab.transform.SetParent(transform);
            prefab.AddComponent<AudioSource>();
            prefab.AddComponent<SoundEmitter>();
            prefab.Reset();
            GameObjectPoolMgr.S.AddPool(POOL_NAME, prefab, 10, this.transform);
            Destroy(prefab);
        }

        public void Init() { }

        public void PlayAudioCue(AudioCueSO audioCue, AudioConfigurationSO setting, Vector3 position = default)
        {
            AudioClip[] clipsToPlay = audioCue.GetClips();
            SoundEmitter[] soundEmitterArray = new SoundEmitter[clipsToPlay.Length];

            for (int i = 0; i < clipsToPlay.Length; i++)
            {
                soundEmitterArray[i] = GameObjectPoolMgr.S.Allocate(POOL_NAME).GetComponent<SoundEmitter>();
                if (soundEmitterArray[i] != null)
                {
                    soundEmitterArray[i].PlayAudioClip(clipsToPlay[i], setting, position);
                }
            }
        }


    }

}