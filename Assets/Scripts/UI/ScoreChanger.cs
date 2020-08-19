using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChanger : MonoBehaviour
{

    [Header("Change Speed")]
    public int motionChanged = 0;
    public int waterChanged = 0;
    public int speedChanged = 0;
    public int spdMotionChanged = 0;
    public GameObject waterControlGo;

    [Header("Set Directly")]
    public int motionSpeed = 0;
    public int waterSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetMotionSpeed()
    {
        waterControlGo.GetComponent<WaterController>().motionSpeed = motionSpeed;    
    }

    public void SetWaterSpeed()
    {
        waterControlGo.GetComponent<WaterController>().useSpeed = waterSpeed;
    }

    public void ChangeScore()
    {
        waterControlGo.GetComponent<WaterController>().totalMotion += motionChanged;
        waterControlGo.GetComponent<WaterController>().totalWater += waterChanged;
        waterControlGo.GetComponent<WaterController>().useSpeed += speedChanged;
        waterControlGo.GetComponent<WaterController>().motionSpeed += spdMotionChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
