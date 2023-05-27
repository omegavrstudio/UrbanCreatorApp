using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestChallange", menuName = "QuestCity/Create Challange", order = 1)]
public class ChallangeSettings : ScriptableObject
{
    public string Title;
    public string Description;
    public int LevelUnlock;

    public bool ListenLevel;
    public float CityLevelToAchive;

    public bool ListenCoins;
    public float CoinsCountToAchive;

    public bool ListenPeople;
    public float PeoplesCountToAchive;

    public bool ListenBuildings;
    public float BuildingsCountToAchive;

    public bool ListenRegions;
    public float RegionsCount;

    public bool ListenHappy;
    public float HappyIndexToAchive;

    public bool ListenUniqueBuildings;
    public float UniqueBuildingsToAchive;

    [Header("Награды")]
    public float CoinsAward;
    public float HappyAward;
    public float ExpAward;
    public float PeoplesAward;
    public float RegionsAward;
    public float BuildingsCountAward;
    public float UniqueBuildingsAward;

}
