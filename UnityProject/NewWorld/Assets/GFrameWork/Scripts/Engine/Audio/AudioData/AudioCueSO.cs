/************************
	FileName:/GFrameWork/Scripts/Engine/Audio/AudioData/AudioSourceSO.cs
	CreateAuthor:neo.xu
	CreateTime:2/7/2021 7:34:26 PM
	Tip:2/7/2021 7:34:26 PM
************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GFrame
{
    [CreateAssetMenu(fileName = "newAudioCue", menuName = "Audio/Audio Cue")]
    public class AudioCueSO : ScriptableObject
    {
        public bool looping = false;
        [SerializeField] private AudioClipsGroup[] audioClipsGroups = default;


        // public AudioClip[] GetClip(){}
    }

    [System.Serializable]
    public class AudioClipsGroup
    {
        public SequenceMode sequenceMode = SequenceMode.Sequeue;
        public AudioClip[] audioClips;

        private int m_NextClipToPlay = -1;
        private int m_LastClipPlayed = -1;

        public AudioClip GetNextClip()
        {
            if (audioClips.Length == 0)
            {
                return audioClips[0];
            }

            if (m_NextClipToPlay == -1)//还没播放过
            {
                m_NextClipToPlay = (sequenceMode == SequenceMode.Sequeue) ? 0 : Random.Range(0, audioClips.Length);
            }
            else
            {
                switch (sequenceMode)
                {
                    case SequenceMode.Random:
                        m_NextClipToPlay = Random.Range(0, audioClips.Length);
                        break;

                    case SequenceMode.RandomNoImmediateRepeat:
                        do
                        {
                            m_NextClipToPlay = Random.Range(0, audioClips.Length);
                        } while (m_NextClipToPlay == m_LastClipPlayed);
                        break;

                    case SequenceMode.Sequeue:
                        m_NextClipToPlay++;
                        m_NextClipToPlay = (int)Mathf.Repeat(m_NextClipToPlay, audioClips.Length);
                        break;
                }
            }
            m_LastClipPlayed = m_NextClipToPlay;
            return null;
        }
    }


    public enum SequenceMode
    {
        Random,
        RandomNoImmediateRepeat,//随机并和上一个不重复
        Sequeue,
    }
}