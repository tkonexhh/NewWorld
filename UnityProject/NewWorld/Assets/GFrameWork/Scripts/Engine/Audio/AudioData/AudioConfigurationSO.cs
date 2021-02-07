/************************
	FileName:/GFrameWork/Scripts/Engine/Audio/AudioConfigurationSO.cs
	CreateAuthor:neo.xu
	CreateTime:2/7/2021 7:06:41 PM
	Tip:2/7/2021 7:06:41 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [CreateAssetMenu(fileName = "newAudioConfigurationSO", menuName = "Audio/Audio Configuration")]
    public class AudioConfigurationSO : ScriptableObject
    {
        [SerializeField] private PriorityLevel _priorityLevel = PriorityLevel.Standard;


        [Header("Sound properties")]
        public bool Mute = false;//是否静音
        [Range(0f, 1f)] public float Volume = 1f;//音量
        [Range(-3f, 3f)] public float Pitch = 1f;//音频源的音高
        [Range(-1f, 1f)] public float PanStereo = 0f;
        [Range(0f, 1f)] public float SpatialBlend = 1f;//设置 3D 空间化计算（衰减、多普勒效应等）对该 AudioSource 的影响程度。0.0 使声音变成全 2D 效果，1.0 使其变成全 3D。
        [Range(0f, 1.1f)] public float ReverbZoneMix = 1f;//将来自 AudioSource 的信号混合到与混响区关联的全局混响中的量。

        [Header("3D sound Settings")]
        [Range(0f, 5f)] public float DopplerLevel = 1f;//设置该 AudioSource 的多普勒缩放。
        [Range(0, 360)] public int Spread = 0;//设置扬声器空间中 3D 立体声或多声道声音的扩散角度（以度为单位）。
        public AudioRolloffMode VolumeRolloffMode = AudioRolloffMode.Logarithmic;
        [Range(0.1f, 5f)] public float MinDistance = 0.1f;
        [Range(5f, 100f)] public float MaxDistance = 50f;

        [Header("Ignores")]
        public bool BypassEffects = false;
        public bool BypassListenerEffects = false;
        public bool BypassReverbZones = false;


        [HideInInspector]
        public int Priority
        {
            get { return (int)_priorityLevel; }
            set { _priorityLevel = (PriorityLevel)value; }
        }



        private enum PriorityLevel
        {
            Highest = 0,
            High = 64,
            Standard = 128,
            Low = 194,
            VeryLow = 256,
        }

        public void ApplyTo(AudioSource audioSource)
        {
            // audioSource.outputAudioMixerGroup = this.OutputAudioMixerGroup;
            audioSource.mute = this.Mute;
            audioSource.bypassEffects = this.BypassEffects;
            audioSource.bypassListenerEffects = this.BypassListenerEffects;
            audioSource.bypassReverbZones = this.BypassReverbZones;
            audioSource.priority = this.Priority;
            audioSource.volume = this.Volume;
            audioSource.pitch = this.Pitch;
            audioSource.panStereo = this.PanStereo;
            audioSource.spatialBlend = this.SpatialBlend;
            audioSource.reverbZoneMix = this.ReverbZoneMix;
            audioSource.dopplerLevel = this.DopplerLevel;
            audioSource.spread = this.Spread;
            audioSource.rolloffMode = this.VolumeRolloffMode;
            audioSource.minDistance = this.MinDistance;
            audioSource.maxDistance = this.MaxDistance;
            // audioSource.ignoreListenerVolume = this.IgnoreListenerVolume;
            // audioSource.ignoreListenerPause = this.IgnoreListenerPause;
        }
    }

}