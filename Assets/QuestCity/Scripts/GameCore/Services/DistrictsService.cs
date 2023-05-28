
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Interfaces;
using QuestCity.GameCore.Base;

namespace QuestCity.GameCore.Services
{
	public class DistrictsService : ServiceBase, IDistrictsService
	{
		[SerializeField] private Material LockedDestrictMaterial;
		[SerializeField] private Material UnknowDestrictMaterial;
		[SerializeField] private Material LifeDestrictMaterial;
		[SerializeField] private Material IndustrialDestrictMaterial;
		[SerializeField] private Material CommercialDestrictMaterial;

		[SerializeField] private List<BaseDistrict> districts = new List<BaseDistrict>();
		public override void Initialize()
		{
			base.Initialize();
		}

		private void OnEnable()
		{
			ScanDestricts();
		}

		public void ScanDestricts() 
		{
			districts.Clear();
			BaseDistrict[] baseDistricts = FindObjectsOfType<BaseDistrict>();
			foreach (BaseDistrict baseDistrict in baseDistricts) districts.Add(baseDistrict);

			foreach (BaseDistrict baseDistrict in baseDistricts) {
				if (!baseDistrict.DistrictSettings) continue;

				if (baseDistrict.DisctrictExist) {
					switch (baseDistrict.DistrictSettings.DistrictType)
					{
						case Models.DisctritsType.Life:
							baseDistrict.DistrictMesh.GetComponent<Renderer>().material = LifeDestrictMaterial;
							break;
						case Models.DisctritsType.Commercial:
							baseDistrict.DistrictMesh.GetComponent<Renderer>().material = CommercialDestrictMaterial;
							break;
						case Models.DisctritsType.Industrial:
							baseDistrict.DistrictMesh.GetComponent<Renderer>().material = IndustrialDestrictMaterial;
							break;
						case Models.DisctritsType.None:
							baseDistrict.DistrictMesh.GetComponent<Renderer>().material = UnknowDestrictMaterial;
							break;
						default:
							break;
					}
				}
				else {
					baseDistrict.DistrictMesh.GetComponent<Renderer>().material = LockedDestrictMaterial;
				}

			}

			Debug.Log(districts.ToString());
		}
	}
}