using QuestCity.Core.Patterns;
using QuestCity.GameCore.Interfaces;
using QuestCity.GameCore.Structures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace QuestCity.GameCore.Services {
	public class ChallengeService : MonoBehaviour, IChallangeService
	{
		[SerializeField] private List<Challange> allChallanges = new List<Challange>();
		[SerializeField] private List<Challange> activeChallanges = new List<Challange>();
		public UnityEvent<Challange> OnComplete = new UnityEvent<Challange>();

		private CityStatisticStruct prevCityStatistic;
		
		public void Comply(int challangeId) 
		{
			activeChallanges[challangeId].Comply();
            OnComplete.Invoke(activeChallanges[challangeId]);
		}
		public void Comply(string challangeName)
		{
			foreach (Challange challange in activeChallanges)
				if (challange.properties.name == challangeName) {
					challange.Comply();
					OnComplete.Invoke(challange);
					return;
				}
		}
		private void onCompleted(Challange challange)
		{
			activeChallanges.Remove(challange);
			AddAwards(challange);
		}


		private void AddAwards(Challange challange) 
		{
			ICityStatisticsService service = ServiceLocator.Current.Get<ICityStatisticsService>();
			service.AddCoin(challange.properties.CoinsAward);
			service.AddHappy(challange.properties.HappyAward);
			service.AddBuildings(challange.properties.BuildingsCountAward);
			service.AddUniqueBuildings(challange.properties.UniqueBuildingsAward);
			service.AddPeople(challange.properties.PeoplesAward);
			service.AddRegions(challange.properties.RegionsAward);
			service.AddExperience(challange.properties.ExpAward);
		}


		private void Awake()
		{
			OnComplete.AddListener(onCompleted);

		}


		private void OnEnable()
		{
			EventHolder<CityStatisticProvider>.AddListeneer(OnStatisticChanged, true);
		}



		private void OnDisable()
		{
			EventHolder<CityStatisticProvider>.RemoveListener(OnStatisticChanged);
		}


		private void OnStatisticChanged(CityStatisticProvider provider)
		{
			if (prevCityStatistic.Equals(null)) {
				UpdateCityLevel(provider.CityStatistics.CityLevel);
				return;
			}
			CityStatisticStruct cityStatistics = provider.CityStatistics;

			if (prevCityStatistic.CityLevel != cityStatistics.CityLevel) UpdateCityLevel(cityStatistics.CityLevel);

			if (prevCityStatistic.UniqueBuildings != cityStatistics.UniqueBuildings) UpdateUniqueBuildings(cityStatistics.UniqueBuildings);
			if (prevCityStatistic.BuildingsCount != cityStatistics.BuildingsCount) UpdateBuildingsCount(cityStatistics.BuildingsCount);
			if (prevCityStatistic.CoinsCount != cityStatistics.CoinsCount) UpdateCoinsCount(cityStatistics.CoinsCount);
			if (prevCityStatistic.HappyIndex != cityStatistics.HappyIndex) UpdateHappyIndex(cityStatistics.HappyIndex);
			if (prevCityStatistic.RegionsCount != cityStatistics.RegionsCount) UpdateRegionsCount(cityStatistics.RegionsCount);
			if (prevCityStatistic.PeoplesCount != cityStatistics.PeoplesCount) UpdatePeoplesCount(cityStatistics.PeoplesCount);

			prevCityStatistic = cityStatistics;
		}

		private void UpdatePeoplesCount(float newValue)
		{
			foreach (Challange challange in activeChallanges.ToList())
			{
				if ((challange.properties.ListenPeople) && (challange.properties.PeoplesCountToAchive <= newValue))
				{
					challange.Comply();
					OnComplete.Invoke(challange);
				}
			}
		}

		private void UpdateRegionsCount(float newValue)
		{
			foreach (Challange challange in activeChallanges.ToList())
			{
				if ((challange.properties.ListenRegions) && (challange.properties.RegionsCount <= newValue))
				{
					challange.Comply();
					OnComplete.Invoke(challange);
				}
			}
		}

		private void UpdateHappyIndex(float newValue)
		{
			foreach (Challange challange in activeChallanges.ToList())
			{
				if ((challange.properties.ListenHappy) && (challange.properties.HappyIndexToAchive <= newValue))
				{
					challange.Comply();
					OnComplete.Invoke(challange);
				}
			}
		}

		private void UpdateCoinsCount(float newValue)
		{
			foreach (Challange challange in activeChallanges.ToList())
			{
				if ((challange.properties.ListenCoins) && (challange.properties.CoinsCountToAchive <= newValue))
				{
					challange.Comply();
					OnComplete.Invoke(challange);
				}
			}
		}

		private void UpdateBuildingsCount(float newValue)
		{
			foreach (Challange challange in activeChallanges.ToList())
			{
				if ((challange.properties.ListenBuildings) && (challange.properties.BuildingsCountToAchive <= newValue))
				{
					challange.Comply();
					OnComplete.Invoke(challange);
				}
			}
		}

		private void UpdateUniqueBuildings(float newValue)
		{
			foreach (Challange challange in activeChallanges.ToList())
			{
				if ((challange.properties.ListenUniqueBuildings) && (challange.properties.UniqueBuildingsToAchive <= newValue)) {
					challange.Comply();
					OnComplete.Invoke(challange);
				}
			}
		}

		private void UpdateCityLevel(float newValue)
		{
			foreach (Challange challange in allChallanges.ToList())
			{
				if ((!challange.GetIsComplete()) && (challange.properties.LevelUnlock <= newValue)) {
					activeChallanges.Add(challange);
				}
			}

			foreach (Challange challange in activeChallanges.ToList())
			{
				if ((challange.properties.ListenLevel) && (challange.properties.CityLevelToAchive <= newValue)) { 
					challange.Comply();
					OnComplete.Invoke(challange);
				}

			}
		}

	}

	[System.Serializable]
	public class Challange : ICompletable
	{
		[SerializeField] private bool isComplete;
		public ChallangeSettings properties;


		public void Comply()
		{
			isComplete = true;
		}

		public bool GetIsComplete() => isComplete;
	}

}
