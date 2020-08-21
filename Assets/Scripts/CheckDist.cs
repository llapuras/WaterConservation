using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDist : MonoBehaviour
{
    // Start is called before the first frame update
    public float detectDistance = 1;
    public GameObject mainobj;
    public GameObject goal;
    public WaterController wc;

    public float sanSpdChanged = 5;
   
    public bool isInRain = false;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(goal.transform.position, mainobj.transform.position);

        if (dist < detectDistance && isInRain == false)
        {
            isInRain = true;
            wc.motionSpeed += sanSpdChanged;

        }
        else if(dist > detectDistance && isInRain == true)
        {
            isInRain = false;
            wc.motionSpeed -= sanSpdChanged;
        }
    }

}
