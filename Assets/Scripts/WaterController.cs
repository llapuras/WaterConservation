using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    public Text totalWaterText; //水量显示
    public Text netGainText; //水量显示
    
    private int totalWater;     //水库总量
    public int speedCost;       //每日消耗水量
    public int speedGain;       //每日获得水量
    public int netGain;          //每日净获得水量
    // Start is called before the first frame update
    void Start()
    {
        totalWater = 200;

        speedGain = 2;
        speedCost = 1;

    }

    // Update is called once per frame
    void Update()
    {
        //Water caculator
        netGain = speedGain - speedCost;

        totalWater += speedGain;//获得
        totalWater -= speedCost;//消耗
        
        //UI 
        totalWaterText.text = totalWater.ToString();
        netGainText.text = netGain + "/s";


    }
}
