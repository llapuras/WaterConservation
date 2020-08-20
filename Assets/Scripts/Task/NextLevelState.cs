using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelState : MonoBehaviour
{

    public GameObject[] linesList;//手动加吧QAQ
    public GameObject nextBtn;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (count != linesList.Length)
        {
            nextBtn.SetActive(false);
            count = 0;
            foreach (GameObject go in linesList)
            {
                if (!go.activeSelf) return;
                else count++;
            }  
        }
        else
        {
            nextBtn.SetActive(true);
        }
    }
}
