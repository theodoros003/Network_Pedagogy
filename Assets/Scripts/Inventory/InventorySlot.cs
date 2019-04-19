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

    public float LabIntRadius = 20f;
    public bool inRange = false;
    public Transform player;
    public Transform LabInteraction;

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
        float distance = Vector3.Distance(player.position, LabInteraction.position);
        if (distance <= LabIntRadius)
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
        switch(item.name)
        {
            case "Working Server":
                WorkingServer.SetActive(true);
                succUseMessage();
                OnRemoveButton();
                break;
            case "Broken Servers":
                BrokenServers.SetActive(true);
                succUseMessage();
                OnRemoveButton();
                break;
            case "Working PC":
                WorkingPC.SetActive(true);
                succUseMessage();
                OnRemoveButton();
                break;
            case "Broken PCs":
                BrokenPCs.SetActive(true);
                succUseMessage();
                OnRemoveButton();
                break;
            case "Wires":
                Wires.SetActive(true);
                succUseMessage();
                OnRemoveButton();
                break;
            case "Power Cable":
                bool serverIsTrigger;
                GameObject GreenLight;
                GameObject PowerCable;

                GreenLight = WorkingServer.GetComponent<ServerUI>().GreenLight;
                serverIsTrigger = WorkingServer.GetComponent<ServerUI>().isTrigger;
                PowerCable = WorkingServer.GetComponent<ServerUI>().PowerCable;

                if (serverIsTrigger == false)
                {
                    canvas.GetComponent<MessageUI>().startServerMessage();
                    //serverDistanceMessage.SetActive(true);
                }
                if (serverIsTrigger == true)
                {
                    canvas.GetComponent<MessageUI>().startServerSuccMessage();
                    PowerCable.SetActive(true);
                    PowerCable.GetComponent<Animator>().Play("CableAnimation");
                    WorkingServer.GetComponent<ServerUI>().powerIsOn = true;
                    GreenLight.SetActive(true);
                    OnRemoveButton();
                }
                break;
            case "Ethernet Cable":
                GameObject ethernetCable;

                serverIsTrigger = WorkingServer.GetComponent<ServerUI>().isTrigger;
                ethernetCable = WorkingServer.GetComponent<ServerUI>().EthernetCable;

                if (serverIsTrigger == false)
                {
                    canvas.GetComponent<MessageUI>().startEthernetMessage();
                }
                if (serverIsTrigger == true)
                {
                    canvas.GetComponent<MessageUI>().startEthernetSuccMessage();
                    ethernetCable.SetActive(true);
                    ethernetCable.GetComponent<Animator>().Play("EthernetCableAnimation");
                    WorkingServer.GetComponent<ServerUI>().ethernetIsOn = true;
                    OnRemoveButton();
                }
                break;
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
