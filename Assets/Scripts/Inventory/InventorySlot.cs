using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Text itemInfo;

    public GameObject note1;
    public GameObject note2;

    Item item;

    public float radius = 4f;
    public bool inRange = false;
    public Transform player;
    public Transform interaction;

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot ()
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

    public void UseItem ()
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
        if (item != null)
        {
            if (inRange == true)
            {
                Debug.Log("working");
            }
            if (item.name == "Note 1")
            {
                note1.SetActive(!note1.activeSelf);
            }
            if (item.name == "Note 2")
            {
                note2.SetActive(!note2.activeSelf);
            }
            item.Use();
        }
    }

    public void mouseOverText()
    {
        if (item != null)
        {
            itemInfo.enabled = true;
            itemInfo.text = item.name;
            Debug.Log("mouse over");
        }
    }

    public void mouseExitText()
    {
        itemInfo.enabled = false;
    }

}
