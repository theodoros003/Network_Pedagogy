using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TermTrigerMes : MonoBehaviour
{
    public GameObject terminalMessage;
    public GameObject terminalUI;
    private bool isTriger;
    public GameObject Player;
    public PlayerCamera playerCamera;
    public bool readyToUse = false;
    public GameObject PcCanvas1;
    public GameObject PcCanvas2;
    public GameObject server;

    private bool powerSupplyBtn = false;
    private bool ethernetBtn = false;
    private bool serverCheck = false;

    void Start() 
    {
        terminalMessage.SetActive(false);
        playerCamera = playerCamera.GetComponent<PlayerCamera>();
        
    }

    void Update() 
    {
        serverCheck = server.GetComponent<ServerUI>().serverIsComplete;
        if (isTriger == true && readyToUse == true && serverCheck == true)
        {
            usingTerminal();
        }
        if (PcCanvas1.activeSelf || PcCanvas2.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PcCanvas1.SetActive(false);
                PcCanvas2.SetActive(false);
            }
        }
    }

    void usingTerminal()
    {
        if (Input.GetButtonDown("Terminal"))
        {
            terminalUI.SetActive(true);
            terminalMessage.SetActive(false);
            Player.SetActive(false);
            playerCamera.isMoving = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            terminalUI.SetActive(false);
            terminalMessage.SetActive(true);
            Player.SetActive(true);
            playerCamera.isMoving = true;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isTriger = true;
            if (readyToUse == false)
            {
                PcCanvas1.SetActive(true);
            }
            if (readyToUse == true && serverCheck == true)
            {
                terminalMessage.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isTriger = false;
            if (readyToUse == false)
            {
                PcCanvas1.SetActive(false);
            }
            if (readyToUse == true && serverCheck == true)
            {
                terminalMessage.SetActive(false);
            }
        }
    }

    public void OnPowerSupplyBtnPress()
    {
        powerSupplyBtn = true;
        checkBtn();
    }

    public void OnEthernetBtnPress()
    {
        ethernetBtn = true;
        checkBtn();
    }
    
    public void checkBtn()
    {
        if (powerSupplyBtn == true && ethernetBtn == true && readyToUse == false)
        {
            PcCanvas1.SetActive(false);
            PcCanvas2.SetActive(true);
            readyToUse = true;
        }
    }
}
