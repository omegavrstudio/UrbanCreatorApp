using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buildManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject model;
    private GameObject _ins;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_ins == null)
        {
            _ins = Instantiate(model, transform.position, Quaternion.identity);
            //DragManager.instance.draged = true;
            _ins.GetComponent<DragManager>().draged = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        //DragManager.instance.draged = false;
        _ins.GetComponent<DragManager>().draged = false;
        _ins = null;
    }
}
