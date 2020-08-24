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

            Log.e(audioClip.length);

            SetAudioImporterStandaloneSetting(importer);
            SetAudioImporterAndroidSetting(importer);
            SetAudioImporterIOSSetting(importer);
        }

        private void SetAudioImporterStandaloneSetting(AudioImporter audioImporter)
        {
            audioImporter.SetOverrideSampleSettings("Standalone", new AudioImporterSampleSettings
            {
                quality = AudioPreprocessorConfig.standaloneConfig.Quality,
            });
        }

        private void SetAudioImporterAndroidSetting(AudioImporter audioImporter)
        {
            audioImporter.SetOverrideSampleSettings("Android", new AudioImporterSampleSettings
            {
                quality = AudioPreprocessorConfig.androidConfig.Quality,
            });
        }

        private void SetAudioImporterIOSSetting(AudioImporter audioImporter)
        {
            audioImporter.SetOverrideSampleSettings("iOS", new AudioImporterSampleSettings
            {
                quality = AudioPreprocessorConfig.iosConfig.Quality,
            });
        }
    }
}
