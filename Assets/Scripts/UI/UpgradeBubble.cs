using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBubble : MonoBehaviour
{
    public Collider coll;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                go.SetActive(true);
                //transform.position = ray.GetPoint(10.0f);
            }
        }
    }

}
