using QuestCity.GameCore.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DistrictSettings", menuName = "QuestCity/Create DistrictSettings", order = 1)]
public class DistrictSettings : ScriptableObject
{
    public string DistrictName;
    public DisctritsType DistrictType;
    public float MaxBuildingCount;
    public float DefaultBuildingCount;
    public float DefaultPeopleCount;
    public float CostToCreate;
    public float CostToDestroy;
}
