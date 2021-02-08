/************************
	FileName:/GFrameWork/Scripts/Engine/Audio/AudioCue.cs
	CreateAuthor:neo.xu
	CreateTime:2/8/2021 9:52:23 AM
	Tip:2/8/2021 9:52:23 AM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    public class AudioCue : MonoBehaviour
    {
        [Header("Sound definition")]
        [SerializeField] private AudioCueSO m_AudioCue = default;
        [SerializeField] private bool m_PlayOnStart = false;

        [Header("Configuration")]
        [SerializeField] private AudioConfigurationSO m_AudioConfiguration = default;


        private void Start()
        {
            if (m_PlayOnStart)
                StartCoroutine(PlayDelayed());
        }

        private IEnumerator PlayDelayed()
        {
            yield return new WaitForSeconds(.1f);

            PlayAudioCue();
        }

        public void PlayAudioCue()
        {
            Debug.LogError("PlayAudio");
            AudioMgr.S.PlayAudioCue(m_AudioCue, m_AudioConfiguration, transform.position);
        }
    }

}