using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.Core.Interfaces;

namespace QuestCity.GameCore.Interfaces
{
    public interface ISoundService : IService
    {
        void PlayAudio(int soundNumber);
        void PlayAudio(string name);
        
    }
}
