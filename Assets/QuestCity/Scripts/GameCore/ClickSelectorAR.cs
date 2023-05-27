using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestCity.GameCore.Interfaces;

public class ClickSelectorAR : MonoBehaviour
{
    public Camera arcamera;

    public ISelectable currentSelectedObject;

    private void OnEnable()
    {
        InputManagerAR.Instance.OnStartTouch += Instance_OnStartTouch;
    }

    private void OnDisable()
    {
        InputManagerAR.Instance.OnStartTouch -= Instance_OnStartTouch;
    }

    private void Instance_OnStartTouch(Vector2 position, float time)
    {
        if (position.x > 0)
        {
            if (currentSelectedObject != null)
            {
                currentSelectedObject.Deselct();
                currentSelectedObject = null;
            }


            Ray ray = arcamera.ScreenPointToRay(position);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                ISelectable selectObject = raycastHit.transform.GetComponent<ISelectable>();
                if (selectObject != null)
                {
                    currentSelectedObject = selectObject;
                    selectObject.Select();
                }
            }
        }
    }
}
