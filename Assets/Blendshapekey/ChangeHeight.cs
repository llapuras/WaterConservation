using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHeight : MonoBehaviour
{

    public Transform relaGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(relaGo.position.x,0.4f + relaGo.position.y - relaGo.GetComponent<Wobble>().fillline, relaGo.position.z);
    }
}
