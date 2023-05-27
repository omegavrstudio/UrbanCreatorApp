using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Models;
using QuestCity.GameCore.Interfaces;
using System.Diagnostics;

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

    private void ActivateHighlight()
    {
        LeanTween.scaleZ(OutlineMesh, 100, .5f).setEaseInQuart();
        OutlineMesh.GetComponent<Renderer>().material = DisctrictPlaceMaterial[0];
    }

    private void DeactivateHighlight()
    {
        LeanTween.scaleZ(OutlineMesh, 1, 1).setEaseInElastic();
        OutlineMesh.GetComponent<Renderer>().material = DisctrictPlaceMaterial[1];
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
    }

    public void Deselct()
    {
        DeactivateHighlight();
    }
}
