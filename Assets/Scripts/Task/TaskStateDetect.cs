using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskStateDetect : MonoBehaviour
{
    public bool isFinished = false;
    // Start is called before the first frame update
    public void DetectTaskState()
    {
        if (isFinished)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetFinished()
    {
        isFinished = true;
    }
}
