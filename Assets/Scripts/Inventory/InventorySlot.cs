using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Text itemInfo;

    Item item;

    public GameObject notes;
    public GameObject noteText;

    public float radius = 20f;
    public bool inRange = false;
    public Transform player;
    public Transform interaction;

    public GameObject rangeMessage;
    public GameObject succMessage = null;
    private Text itemMessage;
    private Text itemNote;
    public GameObject server;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        float distance = Vector3.Distance(player.position, interaction.position);
        if (distance <= radius)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (item != null && inRange == true)
        {
            insiteLab();
        }
        if (item != null && item.isNote == true)
        {
            openNotes();
        }
        if (item != null && item.isNote == false && inRange == false)
        {
            StartCoroutine(message1());
        }
    }

    void insiteLab()
    {
        if (item.name == "Server")
        {
            server.SetActive(true);
            StartCoroutine(message2());
            OnRemoveButton();
        }
    }

    IEnumerator message1()
    {
        rangeMessage.SetActive(true);
        yield return new WaitForSeconds(1);
        rangeMessage.SetActive(false);
    }
    IEnumerator message2()
    {
        itemMessage = succMessage.GetComponent<Text>();
        itemMessage.text = item.message;
        succMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        succMessage.SetActive(false);
    }

    void openNotes()
    {
        itemNote = noteText.GetComponent<Text>();
        itemNote.text = item.noteContent;
        notes.SetActive(!notes.activeSelf);
    }

    void mouseOverText()
    {
        if (item != null)
        {
            itemInfo.enabled = true;
            itemInfo.text = item.name;
            Debug.Log("mouse over");
        }
    }

    void mouseExitText()
    {
        itemInfo.enabled = false;
    }

}
