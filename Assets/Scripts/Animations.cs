using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    bool onGround = true;
    void Update()
    {
        PrevAnimator();
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

        Vector3 velocity = GetComponent<UnityEngine.AI.NavMeshAgent>().velocity;
        Vector3 localVel = transform.InverseTransformDirection(velocity);
        float speed = localVel.z;
        GetComponent<Animator>().SetFloat("MoveSpeed", speed);
    }
}
