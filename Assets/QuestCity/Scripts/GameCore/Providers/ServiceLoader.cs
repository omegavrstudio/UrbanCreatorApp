using QuestCity.Core.Patterns;
using QuestCity.GameCore.Interfaces;
using QuestCity.GameCore.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLoader : MonoBehaviour
{
    [SerializeField] private NotificationService _notificationService;
    [SerializeField] private CityStatisticService _cityStatisticService;
    [SerializeField] private SoundService _soundService;
    [SerializeField] private CityResourcesService _cityResourcesService;
    [SerializeField] private AchievementService _achievementService;
    [SerializeField] private ChallengeService _challengeService;


    private void Awake()
    {
        ServiceLocator.Initialize();

        ReigstarionService();
    }

    private void ReigstarionService()
    {
        ServiceLocator.Current.Register<INotificationService>(_notificationService).Initialize();
        ServiceLocator.Current.Register<ICityStatisticsService>(_cityStatisticService).Initialize();
        ServiceLocator.Current.Register<ISoundService>(_soundService).Initialize();
        ServiceLocator.Current.Register<ICityResourcesService>(_cityResourcesService).Initialize();
        ServiceLocator.Current.Register<IAchievementService>(_achievementService).Initialize();
        ServiceLocator.Current.Register<IChallangeService>(_challengeService).Initialize();
    }
}
