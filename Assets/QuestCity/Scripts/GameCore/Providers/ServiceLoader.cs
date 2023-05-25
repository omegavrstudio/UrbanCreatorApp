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

    private void Awake()
    {
        ServiceLocator.Initialize();

        InitializationServices();
    }

    private void InitializationServices()
    {
        ServiceLocator.Current.Register<INotificationService>(_notificationService);
        ServiceLocator.Current.Register<ICityStatisticsService>(_cityStatisticService);
        ServiceLocator.Current.Register<ISoundService>(_soundService);
    }
}
