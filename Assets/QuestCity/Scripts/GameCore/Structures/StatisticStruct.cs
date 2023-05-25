using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestCity.GameCore.Structures
{
    public struct CityStatisticStruct
    {
        public int CoinsCount;
        public int PeoplesCount;
        public int BuildingsCount;
        public int RegionsCount;
        public int HappyIndex;
        public int UniqueBuildings;

        public CityStatisticStruct(int coinsCount = 0, int peoplesCount = 0, int buildingsCount = 0, int regionsCount = 0, int happyIndex = 0, int uniqueBuildings = 0)
        {
            this.CoinsCount = coinsCount;
            this.PeoplesCount = peoplesCount;
            this.BuildingsCount = buildingsCount;
            this.RegionsCount = regionsCount;
            this.HappyIndex = happyIndex;
            this.UniqueBuildings = uniqueBuildings;
        }
    }
}