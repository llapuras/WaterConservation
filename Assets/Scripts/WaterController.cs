using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    [Header("UI")]
    public Text totalWaterText; //water text
    public Text totalMotionText; //motion text

    [Header("Parameters")]
    public float initialWater = 1000; //initial water
    public float initialMotion = 50; //initial motion
    public float useSpeed = 1; //water use speed
    public float motionSpeed = 0; //motion change speed，miotion drop slowly if you do nothing 

    //[Header("Comsume Water")]
    //public GameObject[] eventsList;

    //...
    public float totalWater; //total water
    public float totalMotion; //total motion
    public GameObject clock;

    void Start()
    {
        totalWater = initialWater;
        totalMotion = initialMotion;
    }

    void Update()
    {
        if (!clock.GetComponent<Clock>().isPause)
        {
            //Water Use
            initialWater -= useSpeed * 0.01f;
            totalWater = (int)initialWater;

            //Motion Drop
            initialMotion -= motionSpeed * 0.001f;
            totalMotion = (int)initialMotion;
        }

        //UI 
        totalWaterText.text = totalWater.ToString();
        totalMotionText.text = totalMotion.ToString();
    }
}
