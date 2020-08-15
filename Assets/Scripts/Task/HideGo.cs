using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGo : MonoBehaviour
{

    public GameObject[] gos;
    // Start is called before the first frame update
    public void TurnOffFountain()
    {
        foreach (GameObject x in gos)
        {
            x.SetActive(false);
        }
    }
}
