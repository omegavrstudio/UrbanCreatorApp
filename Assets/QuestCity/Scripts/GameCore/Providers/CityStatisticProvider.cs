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

        private CityStatisticStruct statistic;

        private void Awake()
        {
            if (GetCacheStatistic(out CityStatisticStruct cityStatisticStruct))
            {
                statistic = cityStatisticStruct;
            }
            else
            {
                statistic = new CityStatisticStruct();
            }
        }

        private bool GetCacheStatistic(out CityStatisticStruct cityStatisticStruct)
        {
            cityStatisticStruct = new CityStatisticStruct();
            return true;
        }

        public void UpdateStatistics()
        {
            EventHolder<CityStatisticProvider>.RaiseRegistraionInfo(this);
        }

        public virtual void AddCoin()
        {
            UpdateStatistics();
        }

        public virtual void AddPeople()
        {
            UpdateStatistics();
        }

        public virtual void AddBuildings()
        {
            UpdateStatistics();
        }

        public virtual void AddRegions()
        {
            UpdateStatistics();
        }

        public virtual void AddHappy()
        {
            UpdateStatistics();
        }

        public virtual void AddUniqueBuildings()
        {
            UpdateStatistics();
        }
    }
}