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

}

