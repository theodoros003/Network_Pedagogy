using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public GameObject RangeMessage;
    public GameObject SuccessMessage;
    private Text succMessageText;
    public Text succMessageTextInput;
    public GameObject terminalMessage;
    public GameObject ServerMessage;
    public GameObject ServerSuccMessage;
    public GameObject EthernetMessage;
    public GameObject EthernetSuccMessage;

    public void startRangeMessage()
    {
        StartCoroutine(OutOfRangeMessage());
    }
    public void startSuccMessage()
    {
        StartCoroutine(SuccMessage());
    }
    public void startServerMessage()
    {
        StartCoroutine(ServerMess());
    }
    public void startServerSuccMessage()
    {
        StartCoroutine(ServerSuccessMessage());
    }
    public void startEthernetMessage()
    {
        StartCoroutine(EthernetMess());
    }
    public void startEthernetSuccMessage()
    {
        StartCoroutine(EthernetSuccMess());
    }

    IEnumerator OutOfRangeMessage()
    {
        RangeMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        RangeMessage.SetActive(false);
    }

    IEnumerator SuccMessage()
    {
        succMessageText = SuccessMessage.GetComponent<Text>();
        succMessageText = succMessageTextInput;
        SuccessMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        SuccessMessage.SetActive(false);
    }

    IEnumerator ServerMess()
    {
        ServerMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        ServerMessage.SetActive(false);
    }

    IEnumerator ServerSuccessMessage()
    {
        ServerSuccMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        ServerSuccMessage.SetActive(false);
    }

    IEnumerator EthernetMess()
    {
        EthernetMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        EthernetMessage.SetActive(false);
    }

    IEnumerator EthernetSuccMess()
    {
        EthernetSuccMessage.SetActive(true);
        yield return new WaitForSeconds(3);
        EthernetSuccMessage.SetActive(false);
    }

}

