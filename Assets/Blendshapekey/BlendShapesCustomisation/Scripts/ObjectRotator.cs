using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour
{
    float rotSpeed = 120;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        //float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        transform.Rotate(Vector3.up, -rotX);
      //  transform.Rotate(Vector3.right, rotY);
        print("s");
    }
}