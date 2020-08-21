using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfShow : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            go.SetActive(true);
        }
    }
}
