using QuestCity.Core.Interfaces;
using QuestCity.GameCore.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestCity.GameCore.Services
{
    public interface ICityStatisticsService : IService
    {
        public virtual CityStatisticStruct GetStatistic() { return default; }
        public virtual void AddCoin() { }
        public virtual void AddPeople() { }
        public virtual void AddBuildings() { }
        public virtual void AddRegions() { }
        public virtual void AddHappy() { }
        public virtual void AddUniqueBuildings() { }
    }
}