using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Text itemInfo;

    Item item;

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
        if (item != null)
        {
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
