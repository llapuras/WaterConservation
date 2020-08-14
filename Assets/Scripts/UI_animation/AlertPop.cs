using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

//- 多个alert移动
//- 

public class AlertPop : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 speed;
    public float stopTime;
    private int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        stopTime = 5;
        startPos = new Vector3(1100, 0, 0);
        endPos = new Vector3(830,0,0);
        speed = new Vector3(-4, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
         if (state == 0) Moveout();


    }

    public void Popup() {
        if (transform.position.x > endPos.x)
        {
            transform.Translate(speed, Space.World);
        }
    }

   public void Moveout() {
        if (transform.position.x < startPos.x)
        {
            transform.Translate(-speed, Space.World);
        }
    }

    public void SetState() {
        state = 0;
    }
}
