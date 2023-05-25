using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Base;
using QuestCity.GameCore.Interfaces;
using QuestCity.Core.Patterns;

namespace QuestCity.GameCore.Services
{
    public class CityResourcesService : ServiceBase, ICityResourcesService
    {
        protected override void Start()
        {
            base.Start();
        }

        public override void Initialize()
        {
            base.Initialize();
            StartGenerateCoin();
        }

        private void StartGenerateCoin()
        {
            InvokeRepeating("IncreaseCoin", 1, 1);
        }

        private void IncreaseCoin()
        {
            StartCoroutine("IncreaseCoinAsync");
        }

        private IEnumerator IncreaseCoinAsync()
        {
            float CurrentCiyLevel = ServiceLocator.Current.Get<ICityStatisticsService>().GetStatistic().CityLevel;
            float CurrentPeoplesCount = ServiceLocator.Current.Get<ICityStatisticsService>().GetStatistic().PeoplesCount;
            Debug.Log(CurrentCiyLevel);
            float CoinIncreaseValue = CurrentCiyLevel * 10 + (CurrentPeoplesCount / CurrentCiyLevel * 5f);

            ServiceLocator.Current.Get<ICityStatisticsService>().AddCoin(CoinIncreaseValue);

            yield return null;
        }
    }
}