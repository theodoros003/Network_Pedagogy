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

    public GameObject WorkingServer;
    public GameObject BrokenServers;
    public GameObject WorkingPC;
    public GameObject BrokenPCs;
    public GameObject Wires;

    public GameObject canvas;
    
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
            canvas.GetComponent<MessageUI>().startRangeMessage();
        }
    }

    void insiteLab()
    {
        if (item.name == "Working Server")
        {
            WorkingServer.SetActive(true);
            succUseMessage();
            OnRemoveButton();
        }
        else if (item.name == "Broken Servers")
        {
            BrokenServers.SetActive(true);
            succUseMessage();
            OnRemoveButton();
        }
        else if (item.name == "Working PC")
        {
            WorkingPC.SetActive(true);
            succUseMessage();
            OnRemoveButton();
        }
        else if (item.name == "Broken PCs")
        {
            BrokenPCs.SetActive(true);
            succUseMessage();
            OnRemoveButton();
        }
        else if (item.name == "Wires")
        {
            Wires.SetActive(true);
            succUseMessage();
            OnRemoveButton();
        }
        
    }

    void succUseMessage()
    {
        item.Use();
        itemMessage = succMessage.GetComponent<Text>();
        itemMessage.text = item.message;
        itemMessage = canvas.GetComponent<MessageUI>().succMessageTextInput;
        canvas.GetComponent<MessageUI>().startSuccMessage();
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
