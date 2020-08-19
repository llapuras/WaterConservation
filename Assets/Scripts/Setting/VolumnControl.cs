using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumnControl : MonoBehaviour
{

    [Header("UI Button")]
    public GameObject muteBtn;
    public GameObject playBtn;
    public AudioSource bgm;

    public bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolumn()
    {
        isPause = !isPause;

        if (!isPause)
        {
            muteBtn.SetActive(true);
            playBtn.SetActive(false);
            bgm.volume = 1;
        }
        else
        {
            muteBtn.SetActive(false);
            playBtn.SetActive(true);
            bgm.volume = 0;
        }
    }
}
