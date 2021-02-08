/************************
	FileName:/GFrameWork/Scripts/Engine/Audio/SoundEmitters/SoundEmitter.cs
	CreateAuthor:neo.xu
	CreateTime:2/7/2021 8:31:22 PM
	Tip:2/7/2021 8:31:22 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEmitter : MonoBehaviour
    {
        private AudioSource m_AudioSource;

        private void Awake()
        {
            m_AudioSource = this.GetComponent<AudioSource>();
            m_AudioSource.playOnAwake = false;
        }

        public void PlayAudioClip(AudioClip clip, AudioConfigurationSO setting, Vector3 position = default)
        {
            Debug.LogError("SoundEmitter Play");
            m_AudioSource.clip = clip;
            setting.ApplyTo(m_AudioSource);
            m_AudioSource.transform.position = position;

            m_AudioSource.Play();

        }
    }

}