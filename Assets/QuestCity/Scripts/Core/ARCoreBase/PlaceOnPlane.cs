using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation.Samples;
using UnityEngine.InputSystem;

namespace QuestCity.Core.ARCoreBase
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        [SerializeField]
        private GameObject _placedObject;
        private UnityEvent PlacementUpdate;
        [SerializeField]
        private GameObject _visualIndicator;
        private ARRaycastManager _raycastManager;

        public GameObject PlacedObject
        {
            get { return _placedObject; }
            set { _placedObject = value; }
        }

        public GameObject spawnedObject { get; private set; }

        private List<ARRaycastHit> _hitList = new List<ARRaycastHit>();

        private void Awake()
        {
            _raycastManager = GetComponent<ARRaycastManager>();
            InputManagerAR.Instance.OnStartTouch += Instance_OnStartTouch;
        }

        private void Instance_OnStartTouch(Vector2 position, float time)
        {
            if (_raycastManager.Raycast(position, _hitList, TrackableType.Planes))
            {
                var hitPose = _hitList[0].pose;

                Instantiate(PlacedObject, hitPose.position, hitPose.rotation);
            }
        }
    }
}