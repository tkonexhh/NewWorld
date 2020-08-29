/************************
	FileName:/GFrameWork/Tools/Postprocessor/AudioPreprocessorConfig.cs
	CreateAuthor:neo.xu
	CreateTime:8/21/2020 4:10:13 PM
	Tip:8/21/2020 4:10:13 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame.AssetPreprocessor
{
    public class AudioPreprocessorConfig : BasePreprocessorConfig<AudioPreprocessorConfig>
    {

        [Header("Quality Settings")]
        [SerializeField] private bool ForceToMono = true;//单声道
        [SerializeField] private bool Ambisonic = false; //环绕声

        //[Range(0, 1)] [SerializeField] private float Quality = 1f;

        // [Header("Match Criteria")]
        // [SerializeField] private float MaxClipLengthInSeconds = 999f;

        [Header("Load Settings")]
        [SerializeField] private bool LoadInBackground = false;
        //[SerializeField] private AudioClipLoadType AudioClipLoadType = AudioClipLoadType.DecompressOnLoad;


        [Header("Platform")]
        [SerializeField] private AudioPlatformPreprocessorConfig StandaloneConfig;
        [SerializeField] private AudioPlatformPreprocessorConfig AndroidConfig;
        [SerializeField] private AudioPlatformPreprocessorConfig IOSConfig;


        public static bool forceToMono => S.ForceToMono;
        public static bool ambisonic => S.Ambisonic;
        public static bool loadInBackground => S.LoadInBackground;

        public static AudioPlatformPreprocessorConfig standaloneConfig => S.StandaloneConfig;
        public static AudioPlatformPreprocessorConfig androidConfig => S.AndroidConfig;
        public static AudioPlatformPreprocessorConfig iosConfig => S.IOSConfig;

    }


    [System.Serializable]
    public class AudioPlatformPreprocessorConfig
    {
        [Range(0, 1)] public float Quality = 1f;
        public bool PreloadAudioData = false;
        public AudioCompressionFormat AudioCompressionFormat = AudioCompressionFormat.Vorbis;

    }

    // [System.Serializable]
    // public class AudioStandalonePreprocessorConfig : AudioPlatformPreprocessorConfig
    // {

    //     public bool PreloadAudioData = true;
    //     public AudioCompressionFormat AudioCompressionFormat = AudioCompressionFormat.Vorbis;
    // }

    // [System.Serializable]
    // public class AudioAnndroidPreprocessorConfig : AudioPlatformPreprocessorConfig
    // {

    //     public bool PreloadAudioData = true;
    //     public AudioCompressionFormat AudioCompressionFormat = AudioCompressionFormat.Vorbis;
    // }

    // [System.Serializable]
    // public class AudioIOSPreprocessorConfig : AudioPlatformPreprocessorConfig
    // {
    //     public bool PreloadAudioData = true;
    //     public AudioCompressionFormat AudioCompressionFormat = AudioCompressionFormat.MP3;
    // }

}