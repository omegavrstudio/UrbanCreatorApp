using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Structures;
using QuestCity.GameCore.Base;
using QuestCity.Core.Patterns;

namespace QuestCity.GameCore.Services
{
    public class CityStatisticService : ServiceBase, ICityStatisticsService
    {
        private CityStatisticProvider cityStatistic;

        protected override void Awake()
        {
            base.Awake();
            cityStatistic = FindAnyObjectByType<CityStatisticProvider>();
        }

        protected override void Start()
        {
            base.Start();
        }

        public virtual CityStatisticStruct GetStatistic()
        {
            return cityStatistic.CityStatistics;
        }

        public virtual void AddCoin()
        {
            cityStatistic.AddCoin();
        }

        public virtual void AddPeople()
        {
            cityStatistic.AddPeople();
        }

        public virtual void AddBuildings()
        {
            cityStatistic.AddBuildings();
        }

        public virtual void AddRegions()
        {
            cityStatistic.AddRegions();
        }

        public virtual void AddHappy()
        {
            cityStatistic.AddHappy();
        }

        public virtual void AddUniqueBuildings()
        {
            cityStatistic.AddUniqueBuildings();
        }
    }
}