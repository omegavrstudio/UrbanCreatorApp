using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.Core.Interfaces;

namespace QuestCity.GameCore.Base
{
    public class ServiceBase : MonoBehaviour, IService
    {
        protected virtual void Awake()
        {
            
        }

        protected virtual void Start()
        {
            
        }

        public virtual void Initialize()
        {
        }

        public virtual void Deinitialize()
        {
        }
    }
}