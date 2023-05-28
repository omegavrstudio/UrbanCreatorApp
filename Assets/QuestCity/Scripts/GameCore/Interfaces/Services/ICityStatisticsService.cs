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
        public virtual void AddCoin(float coinCount) { }
        public virtual void SubCoin(float coinCount) { }
        public virtual float GetCoin() { return 0.0f; }
        public virtual void AddPeople(float pepole) { }
        public virtual void AddBuildings(float buildingCount) { }
        public virtual void AddRegions(float regionCount) { }
        public virtual void AddHappy(float happyCount) { }
        public virtual void AddUniqueBuildings(float uniqueBuildingsCount) { }
        public virtual void AddExperience(float experience) { }
    }
}