using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{

    public float totalwater;
    public float totalmotion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(totalwater <=0 || totalmotion <= 0)
        {
            Debug.Log("Game Over!");
            //pop up game over page
            //restart or back to menu
        }
    }
}
