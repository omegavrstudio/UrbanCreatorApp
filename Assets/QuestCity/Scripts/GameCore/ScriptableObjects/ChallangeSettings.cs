using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestChallange", menuName = "QuestCity/Create Challange", order = 1)]
public class ChallangeSettings : ScriptableObject
{
    public string Title;
    public string Description;

    public bool Level;
    public float CityLevelToAchive;
    public bool Coins;
    public float CoinsCountToAchive;
    public bool Pepole;
    public float PeoplesCountToAchive;
    public bool Buildings;
    public float BuildingsCountToAchiveToAchive;
    public bool Regions;
    public float RegionsCount;
    public bool Happy;
    public float HappyIndexToAchive;
    public bool UniqueBuildings;
    public float UniqueBuildingsToAchive;
}
