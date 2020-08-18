using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LocomotionSimpleAgent : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private float velocity = 0;
    private RaycastHit hitInfo = new RaycastHit();
    private Vector3 lastPosition;

    public Vector3 des;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                agent.destination = hitInfo.point;
            des = hitInfo.point;
        }

        velocity = Mathf.Lerp(velocity, (transform.position - lastPosition).magnitude / Time.deltaTime, 0.3f);
        lastPosition = transform.position;


        anim.SetFloat("velocity", velocity);

        if (Vector3.Magnitude(transform.position - agent.destination) > 0.01f)
        {
            anim.SetBool("iswalking", true);
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
    }

}