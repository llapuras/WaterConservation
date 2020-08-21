using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingMove : MonoBehaviour
{

    public float speed = 1;
    public GameObject txt;
    public GameObject bg;
    public GameObject bgm2;
    public GameObject bgm1;
    public GameObject menubtn;

    // Start is called before the first frame update
    void Start()
    {
        menubtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (txt.transform.position.y < 3200)
        {
            txt.transform.Translate(Vector3.up * speed, Space.World);
        }
        else
        {
            bg.SetActive(false);
            bgm1.SetActive(false);
            bgm2.SetActive(true);
            menubtn.SetActive(true);
        }
    }
}
