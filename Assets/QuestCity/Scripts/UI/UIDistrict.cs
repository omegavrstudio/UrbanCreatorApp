using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestCity.Core.Patterns;
using QuestCity.GameCore;
using TMPro;
using Lean.Gui;
using UnityEngine.Events;
using System;

namespace QuestCity.UI {
    public class UIDistrict : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _districtType;
        [SerializeField] private TextMeshProUGUI _peopleCount;
        [SerializeField] private TextMeshProUGUI _buildingCount;
        [SerializeField] private TextMeshProUGUI _costBuy;


        [SerializeField] private LeanWindow _shopWindow;
        [SerializeField] private LeanButton _buyButton;
        [SerializeField] private LeanButton _sellButton;

        public UnityEvent OnBuyDestrict = new UnityEvent();
		public UnityEvent OnSellDestrict = new UnityEvent();

		private void OnEnable()
		{
            _buyButton.OnClick.AddListener(BuyPress);
			_sellButton.OnClick.AddListener(SellPress);
		}

		private void SellPress()
		{
			OnSellDestrict.Invoke();
			
		}

		private void BuyPress()
		{
			OnBuyDestrict.Invoke();
		}

		private void OnDisable()
		{
			_buyButton.OnClick.RemoveListener(BuyPress);
			_sellButton.OnClick.RemoveListener(SellPress);
		}


		public void LoadDataByDestrict(BaseDistrict district) {
            UpdateUI(district);
		}
        private void UpdateUI(BaseDistrict district)
        {
			if (!district.DisctrictExist)
			{
				_buyButton.gameObject.SetActive(true);
				_sellButton.gameObject.SetActive(false);
				_costBuy.text = district.DistrictSettings.CostToCreate.ToString();
			}
			else
			{
				_buyButton.gameObject.SetActive(false);
				_sellButton.gameObject.SetActive(true);
				_costBuy.text= district.DistrictSettings.CostToDestroy.ToString();
			
			}
			

			_buildingCount.text= district.BuildingCount.ToString();
			_peopleCount.text= district.PeopleCount.ToString();

            switch (district.DistrictSettings.DistrictType)
            {
                case GameCore.Models.DisctritsType.None:
					_districtType.text = "без специализации";
					break;
                case GameCore.Models.DisctritsType.Life:
					_districtType.text = "жилой";
                    break;
                case GameCore.Models.DisctritsType.Commercial:
					_districtType.text = "коммерческий";
                    break;
                case GameCore.Models.DisctritsType.Industrial:
					_districtType.text = "индустриальный";
                    break;
                default:
                    break;
            }
		}
       
    }
}
