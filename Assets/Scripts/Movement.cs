using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(MovementPoint))]
public class Movement : MonoBehaviour
{   
    public LayerMask movementMask;
    public Interractions focus;
    
    bool onGround = true;
    MovementPoint point;
    
    void Start() 
    {
        point = GetComponent<MovementPoint>();
    }
    void Update()
    {
        PrevAnimator();
        if(Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.W))
        {
            MoveToCursor();
            RemoveFocus();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClickToObjects();
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
            point.MoveToPoint(hitInfo.point);
        }
    }
    private void ClickToObjects()
    {
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(rayCast, out hitInfo, 100);
        if (isHit == true)
        {
            Interractions interractions = hitInfo.collider.GetComponent<Interractions>();
            if (interractions != null)
            {
                SetFocus(interractions);
            }
        }
    }
    void SetFocus (Interractions newFocus)
    {
        if (newFocus != null)
        {
            if (focus != null)
            {
                focus.OffFocused();
            }
            focus = newFocus;
            point.FollowObject(newFocus);
        }
        
        newFocus.OnFocused(transform);
        
    }
    void RemoveFocus ()
    {
        if (focus != null)
        {
            focus.OffFocused();
        }
        focus = null;
        point.StopFollowObject();
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