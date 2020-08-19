using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    [Header("UI")]
    public Text totalWaterText; //水量显示
    public Text totalMotionText; //心情显示

    [Header("Parameters")]
    public float initialWater = 1000; //初始水量
    public int initialMotion = 50; //初始心情
    public int useSpeed = 1; //初始用水速度

    //[Header("Comsume Water")]
    //public GameObject[] eventsList;

    //...
    public float totalWater; //水总量
    public float totalMotion; //心情总量
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
            initialWater -= useSpeed * 0.1f;
            totalWater = initialWater;
            totalWater = (int)totalWater;
        }

        //UI 
        totalWaterText.text = totalWater.ToString();
        totalMotionText.text = totalMotion.ToString();
    }
}
