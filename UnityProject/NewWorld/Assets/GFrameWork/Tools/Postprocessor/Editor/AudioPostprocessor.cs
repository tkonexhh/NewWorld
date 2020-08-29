using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GFrame.AssetPreprocessor.Editor
{
    public class AudioPostprocessor : AssetPostprocessor
    {

        public void OnPreprocessAudio()
        {
            Debug.Log("OnPreprocessAudio=" + this.assetPath);

        }

        /// <summary>
        /// https://docs.unity3d.com/ScriptReference/AssetPostprocessor.OnPreprocessAudio.html
        /// 
        /// IMPORTANT:
        /// Use OnPostprocessAudio() hook instead of OnPreprocessAudio() since OnPostprocessAudio gives a reference to
        /// the AudioClip, which is needed for AudioClip.length.
        /// </summary>
        private void OnPostprocessAudio(AudioClip audioClip)
        {
            if (!AudioPreprocessorConfig.isEnabled) return;

            Debug.Log("OnPostprocessAudio=" + this.assetPath);
            var importer = assetImporter as AudioImporter;

            if (importer == null) return;

            importer.forceToMono = AudioPreprocessorConfig.forceToMono;
            importer.ambisonic = AudioPreprocessorConfig.ambisonic;
            importer.loadInBackground = AudioPreprocessorConfig.loadInBackground;

            //Log.e(audioClip.length);

            AudioClipLoadType loadType = AudioClipLoadType.DecompressOnLoad;
            if (audioClip.length < 10)
            {
                loadType = AudioClipLoadType.DecompressOnLoad;
            }
            else if (audioClip.length < 120)
            {
                loadType = AudioClipLoadType.CompressedInMemory;
            }
            else
            {
                loadType = AudioClipLoadType.Streaming;
            }

            SetAudioImporterStandaloneSetting(importer, loadType);
            SetAudioImporterAndroidSetting(importer, loadType);
            SetAudioImporterIOSSetting(importer, loadType);
        }

        private void SetAudioImporterStandaloneSetting(AudioImporter audioImporter, AudioClipLoadType loadType)
        {
            audioImporter.SetOverrideSampleSettings("Standalone", new AudioImporterSampleSettings
            {
                quality = AudioPreprocessorConfig.standaloneConfig.Quality,
                loadType = loadType
            });
        }

        private void SetAudioImporterAndroidSetting(AudioImporter audioImporter, AudioClipLoadType loadType)
        {
            audioImporter.SetOverrideSampleSettings("Android", new AudioImporterSampleSettings
            {
                quality = AudioPreprocessorConfig.androidConfig.Quality,
                loadType = loadType
            });
        }

        private void SetAudioImporterIOSSetting(AudioImporter audioImporter, AudioClipLoadType loadType)
        {
            audioImporter.SetOverrideSampleSettings("iOS", new AudioImporterSampleSettings
            {
                quality = AudioPreprocessorConfig.iosConfig.Quality,
                loadType = loadType
            });
        }
    }
}
