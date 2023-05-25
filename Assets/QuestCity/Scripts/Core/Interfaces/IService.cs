using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestCity.Core.Interfaces
{
    public interface IService
    {
        public virtual void Initialize() { }
        public virtual void Deinitialize() { }
    }
}