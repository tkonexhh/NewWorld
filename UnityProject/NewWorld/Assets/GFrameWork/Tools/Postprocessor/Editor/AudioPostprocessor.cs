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
            importer.loadInBackground = AudioPreprocessorConfig.loadInBackground;

        }
    }
}
