using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermTrigerMes : MonoBehaviour
{
    public GameObject terminalMessage;
    public GameObject terminalUI;
    private bool isTriger;
    public GameObject Player;

    public PlayerCamera playerCamera;

    void Start() 
    {
        terminalMessage.SetActive(false);
        playerCamera = playerCamera.GetComponent<PlayerCamera>();
    }

    void Update() 
    {
        if (isTriger == true)
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
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            terminalMessage.SetActive(true);
            isTriger = true;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Player")
        {
            terminalMessage.SetActive(false);
            isTriger = false;
        }
    }
}
