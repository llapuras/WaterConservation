using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectObj : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;

    public GameObject bubble;

    public float detectDistance = 1;

    public GameObject collectUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);

        //Debug.Log(dist);
        if (dist < detectDistance)
        {
            bubble.SetActive(true);
            GetCollected();
        }
        else
        {
            bubble.SetActive(false);
        }
    }

    void GetCollected()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            collectUI.GetComponent<LaundryTaskManager>().addPiles();
            goal.SetActive(false);
            gameObject.SetActive(false);

        }
    }

}
