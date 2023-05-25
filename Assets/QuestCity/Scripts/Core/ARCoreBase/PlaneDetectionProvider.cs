using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using QuestCity.Core.Patterns;
using UnityEngine.Events;

public class PlaneDetectionProvider : MonoBehaviour
{
    [SerializeField]
    private ARPlaneManager arPlaneManager;

    public UnityEvent PlaneWasDetected = new UnityEvent();

    private void Awake()
    {
        if (arPlaneManager == null)
        {
            arPlaneManager = FindObjectOfType<ARPlaneManager>();
        }

        if (arPlaneManager == null)
        {
            Debug.LogError("ARPlaneManager not found");
            return;
        }
    }

    private void OnEnable()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var newPlane in eventArgs.added)
        {
            PlaneWasDetected.Invoke();
        }

        foreach (var updatedPlane in eventArgs.updated)
        {
        }

        foreach (var removedPlane in eventArgs.removed)
        {
        }
    }
}
