using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeKeyController : MonoBehaviour
{
    private float mSize = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Scale", 0, 0.02f);
    }

    void Scale()
    {
        if (mSize >= 1)
        {
            CancelInvoke("Scale");
        }

        GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, mSize++);
    }

    // Update is called once per frame
    void Update()
    {
        Scale();
    }
}
