using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectDistance : MonoBehaviour
{

    //摄像机切换
    public GameObject switchCamera;//该任务对应的摄像头
    public GameObject mainCamera;//该任务对应的摄像头

    public GameObject player;
    public GameObject goal;

    public GameObject bubble;

    public float detectDistance = 1;

    public GameObject TaskUI;
    public GameObject DialogueUI;

    void Start()
    {
        goal = gameObject;
        bubble = transform.Find("round").gameObject;
        //switchCamera = gameObject.transform.Find("Camera1").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(dist);
        if (dist < detectDistance)
        {
            bubble.SetActive(true);
            QuestPopUp();
        }
        else
        {
            bubble.SetActive(false);
        }

    }

    void QuestPopUp()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            switchCamera.SetActive(false);
            mainCamera.SetActive(true);
            player.SetActive(true);
            TaskUI.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            switchCamera.SetActive(true);
            mainCamera.SetActive(false);
            gameObject.SetActive(false);
            player.SetActive(false);
            TaskUI.SetActive(true);

            if (DialogueUI != null)
            {
                DialogueUI.SetActive(true);//如果有对话就播对话
                DialogueUI.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }

}
