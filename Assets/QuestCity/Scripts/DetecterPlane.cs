using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;

public class DetecterPlane : MonoBehaviour
{
    [SerializeField] private ARPlaneManager planeManager;
    public UnityEvent OnDetectedPlate = new UnityEvent();

    private void OnEnable()
    {
        planeManager.planesChanged += PlaneManager_planesChanged;
    }
    private void OnDisable()
    {
        planeManager.planesChanged -= PlaneManager_planesChanged;
    }

    private void PlaneManager_planesChanged(ARPlanesChangedEventArgs obj)
    {
        OnDetectedPlate.Invoke();
        this.enabled = false;
    }
}
