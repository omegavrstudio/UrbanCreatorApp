using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace QuestCity.Core
{
    public class PlaceIndicator : MonoBehaviour
    {
        private ARRaycastManager _raycastManager;
        private GameObject _indicator;
        private List<ARRaycastHit> _hitList = new List<ARRaycastHit>();

        void Start()
        {
            _raycastManager = FindAnyObjectByType<ARRaycastManager>();
            _indicator = transform.GetChild(0).gameObject;
            _indicator.SetActive(false);

        }

        void Update()
        {
            var ray = new Vector2(Screen.width / 2, Screen.height / 2);

            if(_raycastManager.Raycast(ray, _hitList, TrackableType.Planes))
            {
                Pose hitPose = _hitList[0].pose;

                transform.position = hitPose.position;
                transform.rotation = hitPose.rotation;

                if(!_indicator.activeInHierarchy)
                {
                    _indicator.SetActive(true);
                }
            }
        }
    }
}