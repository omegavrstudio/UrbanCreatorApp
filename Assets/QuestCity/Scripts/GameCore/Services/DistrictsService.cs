
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Interfaces;
using QuestCity.GameCore.Base;
using QuestCity.UI;
using QuestCity.Core.Patterns;
using Lean.Gui;

namespace QuestCity.GameCore.Services
{
	public class DistrictsService : ServiceBase, IDistrictsService
	{
		[SerializeField] private Material LockedDestrictMaterial;
		[SerializeField] private Material UnknowDestrictMaterial;
		[SerializeField] private Material LifeDestrictMaterial;
		[SerializeField] private Material IndustrialDestrictMaterial;
		[SerializeField] private Material CommercialDestrictMaterial;

		[SerializeField] private BaseDistrict districtSelcted;

		[SerializeField] private LeanWindow _shopWindow;
		[SerializeField] private UIDistrict districtUI;
		[SerializeField] private List<BaseDistrict> districts = new List<BaseDistrict>();
		public override void Initialize()
		{
			base.Initialize();
		}

		private void OnEnable()
		{
			ScanDestricts();

			districtUI.OnSellDestrict.AddListener(SellActiveDestrict);
			districtUI.OnBuyDestrict.AddListener(BuyActiveDestrict);
		}

		private void OnDisable()
		{
			districtUI.OnSellDestrict.RemoveListener(SellActiveDestrict);
			districtUI.OnBuyDestrict.RemoveListener(BuyActiveDestrict);
		}

		public void ScanDestricts() 
		{
			districts.Clear();
			BaseDistrict[] baseDistricts = FindObjectsOfType<BaseDistrict>();
			foreach (BaseDistrict baseDistrict in baseDistricts) districts.Add(baseDistrict);

			foreach (BaseDistrict baseDistrict in baseDistricts) ÑolorizeDestrict(baseDistrict);
		}


		public void OnSelected(BaseDistrict district)
		{
			districtSelcted = district;
			districtUI.LoadDataByDestrict(district);
		}

		public void OnDeselected(BaseDistrict district)
		{
			if (districtSelcted == district) {
				districtSelcted = null;
			}
		}

		public void ÑolorizeDestrict(BaseDistrict baseDistrict) {
			if (!baseDistrict.DistrictSettings) return;

			if (baseDistrict.DisctrictExist)
			{
				switch (baseDistrict.DistrictSettings.DistrictType)
				{
					case Models.DisctritsType.Life:
						baseDistrict.DistrictMesh.GetComponent<Renderer>().material = LifeDestrictMaterial;
						baseDistrict.OutlineMesh.GetComponent<Renderer>().material = LifeDestrictMaterial;
						break;
					case Models.DisctritsType.Commercial:
						baseDistrict.DistrictMesh.GetComponent<Renderer>().material = CommercialDestrictMaterial;
						baseDistrict.OutlineMesh.GetComponent<Renderer>().material = CommercialDestrictMaterial;
						break;
					case Models.DisctritsType.Industrial:
						baseDistrict.DistrictMesh.GetComponent<Renderer>().material = IndustrialDestrictMaterial;
						baseDistrict.OutlineMesh.GetComponent<Renderer>().material = IndustrialDestrictMaterial;
						break;
					case Models.DisctritsType.None:
						baseDistrict.DistrictMesh.GetComponent<Renderer>().material = UnknowDestrictMaterial;
						baseDistrict.OutlineMesh.GetComponent<Renderer>().material = UnknowDestrictMaterial;
						break;
					default:
						break;
				}
			}
			else
			{
				baseDistrict.DistrictMesh.GetComponent<Renderer>().material = LockedDestrictMaterial;
				baseDistrict.OutlineMesh.GetComponent<Renderer>().material = LockedDestrictMaterial;
			}
		}

		public void BuyActiveDestrict()
		{
			ICityStatisticsService service = ServiceLocator.Current.Get<ICityStatisticsService>();

			if (districtSelcted.DistrictSettings.CostToCreate > service.GetCoin()) return;
			
			service.SubCoin(districtSelcted.DistrictSettings.CostToCreate);
			
	
			districtSelcted.CreateDistrict();
			districtUI.LoadDataByDestrict(districtSelcted);
			ÑolorizeDestrict(districtSelcted);
			_shopWindow.TurnOff();
		}

		public void SellActiveDestrict()
		{
			ICityStatisticsService service = ServiceLocator.Current.Get<ICityStatisticsService>();
			service.AddCoin(districtSelcted.DistrictSettings.CostToDestroy);
			
			districtSelcted.DestroyDistrict();
			districtUI.LoadDataByDestrict(districtSelcted);
			_shopWindow.TurnOff();

		}
	}
}