using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChanger : MonoBehaviour
{

    public int motionChanged = 0;
    public int waterChanged = 0;
    public int speedChanged = 0;
    public GameObject waterControlGo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeScore()
    {
        waterControlGo.GetComponent<WaterController>().totalMotion += motionChanged;
        waterControlGo.GetComponent<WaterController>().totalWater += waterChanged;
        waterControlGo.GetComponent<WaterController>().useSpeed += speedChanged;
        Debug.Log(waterControlGo.GetComponent<WaterController>().useSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
