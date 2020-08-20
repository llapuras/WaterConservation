using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaundryTaskManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int collected = 0;
    public int totalPiles = 5;
    public Text display;

    private bool isReady = false;

    public GameObject dialogue01;
    public GameObject dialogue02;
    public GameObject collectingUI;

    public GameObject collectTrigger;


    public void CheckCollecting()
    {
        if(collected == totalPiles)
        {
            isReady = true;
            dialogue01.SetActive(false);
            dialogue02.SetActive(true);
            dialogue02.GetComponent<DialogueTrigger>().TriggerDialogue();
            collectingUI.SetActive(false);
        }
        else
        {
            isReady = false;
            dialogue02.SetActive(false);
            dialogue01.SetActive(true);
            dialogue01.GetComponent<DialogueTrigger>().TriggerDialogue();
            collectingUI.SetActive(true);

            collectTrigger.SetActive(true);
        }
    }

    public void addPiles()
    {
        collected += 1;
        display.text = collected + " / " + totalPiles;
    }


    void Start()
    {
        display.text = "0 / " + totalPiles;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
