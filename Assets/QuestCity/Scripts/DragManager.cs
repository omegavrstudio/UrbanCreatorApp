using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public LayerMask layer;
    public bool draged;
    public static DragManager instance;

    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (draged)
        {
            if (Physics.Raycast(ray, out hit, 100, layer))
            {
                transform.position = hit.point + new Vector3(0, (float)0.5,0);
            }
        }
    }

    private void OnMouseDrag()
    {
        draged = true;
    }
    private void OnMouseUp()
    {
        draged = false;
    }
}
