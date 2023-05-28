using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestCity.Core.Patterns;
using QuestCity.GameCore;
using TMPro;

namespace QuestCity.UI {
    public class UIProvider : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinValue;
        [SerializeField] private TextMeshProUGUI _cityLvl;
        [SerializeField] private TextMeshProUGUI _expValue;
        [SerializeField] private Slider _happySlider;
        [SerializeField] private Slider _lvlSlider;

        private void OnEnable()
        {
            EventHolder<CityStatisticProvider>.AddListeneer(OnStatisticChanged, true);
        }

        private void OnStatisticChanged(CityStatisticProvider cityStatisticProvider)
        {
            _coinValue.text = cityStatisticProvider.CityStatistics.CoinsCount.ToString();
            _cityLvl.text = cityStatisticProvider.CityStatistics.CityLevel.ToString();
            //_expValue.text =
            _happySlider.value = cityStatisticProvider.CityStatistics.HappyIndex;
            _lvlSlider.value = cityStatisticProvider.CityStatistics.CityLevel;
        }
        private void OnDisable()
        {
            EventHolder<CityStatisticProvider>.RemoveListener(OnStatisticChanged);
        }
    }
}
