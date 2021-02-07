/************************
	FileName:/GFrameWork/Scripts/Engine/Audio/AudioMgr.cs
	CreateAuthor:neo.xu
	CreateTime:7/7/2020 1:33:40 PM
	Tip:7/7/2020 1:33:40 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [TMonoSingletonAttribute("[GFrame]/[Tools]/[AudioMgr]")]
    public class AudioMgr : TMonoSingleton<AudioMgr>
    {
        [SerializeField, Range(0f, 1f)] private float m_MasterVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float m_SoundVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float m_MusicVolume = 1f;

        public void PlayAudio(AudioConfigurationSO setting, Vector3 position = default)
        {

        }


    }

}