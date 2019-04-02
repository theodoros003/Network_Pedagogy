using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToPoint : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() 
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceObject();
        }
    }
    
    public void ToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowObject (Interractions newObject)
    {
        agent.stoppingDistance = newObject.radius * .8f;
        agent.updateRotation = false;
        target = newObject.interaction;
    }

    public void StopFollowObject()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceObject()
    {
        Vector3 diraction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(diraction.x, 0f, diraction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
