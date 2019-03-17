using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MoveToCursor();
        }
    }
    private void MoveToCursor()
    {
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool isHit = Physics.Raycast(rayCast, out hitInfo);
        if (isHit == true)
        {
            GetComponent<NavMeshAgent>().destination = hitInfo.point;
        }
    }

}