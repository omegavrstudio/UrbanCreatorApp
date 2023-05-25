using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestCity.GameCore.Structures
{
    [Serializable]
    public struct CityStatisticStruct
    {
        public float CityLevel;
        public float CoinsCount;
        public float PeoplesCount;
        public float BuildingsCount;
        public float RegionsCount;
        public float HappyIndex;
        public float UniqueBuildings;

        public CityStatisticStruct(float citylevel = 1, float coinsCount = 10000, float peoplesCount = 10, float buildingsCount = 0, float regionsCount = 0, float happyIndex = 0, float uniqueBuildings = 0)
        {
            this.CityLevel = citylevel;
            this.CoinsCount = coinsCount;
            this.PeoplesCount = peoplesCount;
            this.BuildingsCount = buildingsCount;
            this.RegionsCount = regionsCount;
            this.HappyIndex = happyIndex;
            this.UniqueBuildings = uniqueBuildings;
        }
    }
}