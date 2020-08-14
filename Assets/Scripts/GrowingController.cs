using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowingController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] golist;
    public GameObject go_origin;
    public Text t;
    public Slider s;

    float TimeStep = 10; //正常成长状态的

    int state = 0;
    GameObject go;
    public Vector3 gpos;

    private int old = 999;

    void Start()
    {
        for(int i = 0; i < go_origin.transform.childCount; i++)
        {
            golist[i] = go_origin.transform.GetChild(i).gameObject;
        }
        s.minValue = 0;
        s.maxValue = 4;

    }

    // Update is called once per frame
    void Update()
    {
        if (old != s.value)
        {
            Debug.Log(s.value);
            Destroy(go);
            go = (GameObject)Instantiate(golist[(int)s.value], gameObject.transform);
            go.transform.position = gpos;
            t.text = go.name;
            old = (int)s.value;
        }
    }
}
