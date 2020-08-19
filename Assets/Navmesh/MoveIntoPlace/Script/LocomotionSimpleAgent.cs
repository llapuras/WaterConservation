// LocomotionSimpleAgent.cs
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LocomotionSimpleAgent : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
     float velocity = 0;
    RaycastHit hitInfo = new RaycastHit();
    Vector3 lastPosition;
    Vector3 dest;

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
            dest = hitInfo.point;
        }

        velocity = Mathf.Lerp(velocity, (transform.position - lastPosition).magnitude / Time.deltaTime, .1f);
        lastPosition = transform.position;
        //anim.SetFloat("velx", velocity);

        if(Vector3.Magnitude(agent.destination - transform.position) > 0.01f)
        {
            anim.SetBool("iswalking", true);
        }
        else { 
            anim.SetBool("iswalking", false);
        }
      
    }

    void OnAnimatorMove()
    {
        // Update position based on animation movement using navigation surface height
        transform.position = agent.nextPosition;
    }
}