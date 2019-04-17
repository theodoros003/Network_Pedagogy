using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public GameObject rangeMessage;
    public GameObject successMessage;
    private Text succMessageText;
    public Text succMessageTextInput;
    public GameObject terminalMessage;

    public void startRangeMessage()
    {
        StartCoroutine(OutOfRangeMessage());
    }
    public void startSuccMessage()
    {
        StartCoroutine(SuccMessage());
    }

    IEnumerator OutOfRangeMessage()
    {
        rangeMessage.SetActive(true);
        yield return new WaitForSeconds(1);
        rangeMessage.SetActive(false);
    }

    IEnumerator SuccMessage()
    {
        succMessageText = successMessage.GetComponent<Text>();
        succMessageText = succMessageTextInput;
        successMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        successMessage.SetActive(false);
    }

}

