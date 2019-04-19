using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerUI : MonoBehaviour
{
    public GameObject PowerCable;
    public GameObject EthernetCable;
    public GameObject GreenLight;

    public bool isTrigger = false;
    public bool powerIsOn = false;
    public bool ethernetIsOn = false;
    public bool serverIsComplete = false;

    void Start()
    {
        PowerCable.SetActive(false);
        EthernetCable.SetActive(false);
        GreenLight.SetActive(false);
    }

    void Update() 
    {
        if (powerIsOn == true && ethernetIsOn == true)
        {
            serverIsComplete = true;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isTrigger = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
