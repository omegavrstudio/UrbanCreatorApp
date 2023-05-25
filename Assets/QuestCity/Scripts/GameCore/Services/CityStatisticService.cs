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
        }

        protected override void Start()
        {
            base.Start();
        }

        public virtual CityStatisticStruct GetStatistic()
        {
            return cityStatistic.CityStatistics;
        }

        public override void Initialize()
        {
            base.Initialize();
            cityStatistic = FindAnyObjectByType<CityStatisticProvider>();
        }

        public virtual void AddCoin(float coinCount)
        {
            cityStatistic.AddCoin(coinCount);
        }

        public virtual void AddPeople(float pepole)
        {
            cityStatistic.AddPeople(pepole);
        }

        public virtual void AddBuildings(float buildingCount)
        {
            cityStatistic.AddBuildings(buildingCount);
        }

        public virtual void AddRegions(float regionCount)
        {
            cityStatistic.AddRegions(regionCount);
        }

        public virtual void AddHappy(float happyCount)
        {
            cityStatistic.AddHappy(happyCount);
        }

        public virtual void AddUniqueBuildings(float uniqueBuildingsCount)
        {
            cityStatistic.AddUniqueBuildings(uniqueBuildingsCount);
        }
    }
}