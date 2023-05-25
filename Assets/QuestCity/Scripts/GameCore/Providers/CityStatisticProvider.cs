using QuestCity.Core.Patterns;
using QuestCity.GameCore.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QuestCity.GameCore
{
    public class CityStatisticProvider : MonoBehaviour
    {
        public CityStatisticStruct CityStatistics
        {
            get
            { 
                return statistic;
            }

            private set
            {
                statistic  = value;
            }
        }

        [SerializeField]
        private CityStatisticStruct statistic;

        private void Awake()
        {
            if (GetCacheStatistic(out CityStatisticStruct cityStatisticStruct))
            {
                statistic = cityStatisticStruct;
            }
            else
            {
                statistic = new CityStatisticStruct(1, 10000, 10, 0, 0, 0, 0);
            }
        }

        private bool GetCacheStatistic(out CityStatisticStruct cityStatisticStruct)
        {
            cityStatisticStruct = new CityStatisticStruct(1, 10000, 10, 0, 0, 0, 0);
            return true;
        }

        public void UpdateStatistics()
        {
            EventHolder<CityStatisticProvider>.RaiseRegistraionInfo(this);
        }

        public virtual void AddCoin(float coinCount)
        {
            statistic.CoinsCount += coinCount;
            UpdateStatistics();
        }

        public virtual void AddPeople(float peopleCount)
        {
            statistic.PeoplesCount += peopleCount;
            UpdateStatistics();
        }

        public virtual void AddBuildings(float buildingCount)
        {
            statistic.BuildingsCount += buildingCount;
            UpdateStatistics();
        }

        public virtual void AddRegions(float regionsCount)
        {
            statistic.RegionsCount += regionsCount;
            UpdateStatistics();
        }

        public virtual void AddHappy(float happyCount)
        {
            statistic.HappyIndex += happyCount;
            UpdateStatistics();
        }

        public virtual void AddUniqueBuildings(float uniqueBuildingsCount)
        {
            statistic.UniqueBuildings += uniqueBuildingsCount;
            UpdateStatistics();
        }
    }
}