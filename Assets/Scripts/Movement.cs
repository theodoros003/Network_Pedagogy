using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform target;

    public LayerMask movementMask;
    
    bool onGround = true;
    
    void Update()
    {
        PrevAnimator();
        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        if (Input.GetKey(KeyCode.E))
        {
            GetComponent<Animator>().SetTrigger("Wave");
        }
        if (Input.GetKey(KeyCode.F))
        {
            GetComponent<Animator>().SetTrigger("Pickup");
        }
    }

    private void MoveToCursor()
    {
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(rayCast, out hitInfo, 100, movementMask);
        if (isHit == true)
        {
            GetComponent<NavMeshAgent>().destination = hitInfo.point;
        }
    }

    private void PrevAnimator()
    {
        if (onGround == true)
        {
            GetComponent<Animator>().SetBool("Grounded", true);
        }
        else if (onGround == false)
        {
            GetComponent<Animator>().SetBool("Grounded", false);
        }

        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVel = transform.InverseTransformDirection(velocity);
        float speed = localVel.z;
        GetComponent<Animator>().SetFloat("MoveSpeed", speed);
    }
    
}