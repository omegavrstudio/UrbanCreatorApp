using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Interfaces;
using QuestCity.GameCore.Base;

namespace QuestCity.GameCore.Services
{
    public class SoundService : ServiceBase, ISoundService
    {
        [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

        public void PlayAudio(int soundNumber)
        {
            throw new System.NotImplementedException();
        }

        public void StopAllAudio()
        {
            throw new System.NotImplementedException();
        }
    }

    
}