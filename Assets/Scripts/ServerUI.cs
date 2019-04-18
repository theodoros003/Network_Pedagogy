using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerUI : MonoBehaviour
{

    public GameObject PowerCable;

    void Start()
    {
        
    }

    void Update()
    {
        cableAnimation();
    }

    void cableAnimation()
    {
        if (Input.GetKeyDown("j"))
        {
            PowerCable.GetComponent<Animator>().Play("CableAnimation");
        }
    }
}
