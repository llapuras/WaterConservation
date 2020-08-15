using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotate : MonoBehaviour
{

    private bool down = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        down = true;
    }

    private void OnMouseUp()
    {
        down = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            var x = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(transform.position.x, -x, transform.position.z) * 10);
        }
    }
}
