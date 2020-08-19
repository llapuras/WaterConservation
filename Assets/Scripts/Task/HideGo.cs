using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGo : MonoBehaviour
{

    public GameObject[] hideList;
    public GameObject[] showupList;

    //hide and show up
    public void TurnOffFountain()
    {
        foreach (GameObject x in hideList)
        {
            x.SetActive(false);
        }

        foreach (GameObject x in showupList)
        {
            x.SetActive(true);
        }
    }

}
