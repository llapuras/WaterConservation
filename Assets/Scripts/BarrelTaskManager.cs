using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrelTaskManager : MonoBehaviour
{
    public float detectDistance = 1;
    public GameObject mainobj;
    public GameObject goal;
    public Text notice;
    public bool isFinished = false;
    public GameObject endDialogue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(goal.transform.position, mainobj.transform.position);

        if (dist < detectDistance) { 
            notice.text = "1 / 1";
            isFinished = true;
            if (endDialogue.activeSelf==false)
            {
                CheckTaskState();
            }
        }
        else
        {
            notice.text = "0 / 1";
            isFinished = false;
        }
    }

    public void CheckTaskState()
    {
        if (isFinished)
        {
            endDialogue.SetActive(true);
            endDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
