using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.LookAt(cam.transform.position, Vector3.up);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + 180, 0);
    }
}
