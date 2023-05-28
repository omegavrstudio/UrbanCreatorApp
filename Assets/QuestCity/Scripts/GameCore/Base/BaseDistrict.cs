using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Models;
using QuestCity.GameCore.Interfaces;
using System.Diagnostics;
using QuestCity.Core.Patterns;
using QuestCity.GameCore.Services;

public class BaseDistrict : MonoBehaviour, ISelectable
{
    public DistrictSettings DistrictSettings;
    public float PeopleCount;
    public float BuildingCount;
    public GameObject DistrictMesh;
    public GameObject OutlineMesh;
    public float DistrictLevel = 1;
    public bool DisctrictExist = false;
    public List<Material> DisctrictPlaceMaterial = new List<Material>();

	private void Awake()
	{
        if (DistrictSettings) {
			BuildingCount = DistrictSettings.DefaultBuildingCount;
			PeopleCount = DistrictSettings.DefaultPeopleCount;
		}
	}

	private void ActivateHighlight()
    {
        LeanTween.scaleZ(OutlineMesh, 100, .5f).setEaseInQuart();
        OutlineMesh.GetComponent<Renderer>().material = DisctrictPlaceMaterial[0];
    }

    private void DeactivateHighlight()
    {
		IDistrictsService service = ServiceLocator.Current.Get<IDistrictsService>();
        LeanTween.scaleZ(OutlineMesh, 1, 1).setEaseInElastic();
        service.ÑolorizeDestrict(this);
    }

    public void CreateDistrict()
    {
        DisctrictExist = true;
    }

    public void DestroyDistrict()
    {
        DisctrictExist = false;
    }

    public void IncreaseProfitDistrict()
    {

    }

    public void AddPepole()
    {

    }

    public void AddNewBuildng()
    {

    }

    public void UpgradeDistrict()
    {

    }

    public void DowngradeDistrcti()
    {

    }

    public void Select()
    {
        ActivateHighlight();
		IDistrictsService districtsService = ServiceLocator.Current.Get<IDistrictsService>();
		districtsService.OnSelected(this);
	}

    public void Deselct()
    {
        DeactivateHighlight();
		IDistrictsService districtsService = ServiceLocator.Current.Get<IDistrictsService>();
        districtsService.OnDeselected(this);
	}
}
