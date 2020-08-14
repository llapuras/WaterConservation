using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovewithMouse : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = (Input.mousePosition);
        screenPoint.z = 10.0f; //distance of the plane from the camera
        go.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }
}
