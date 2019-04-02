using UnityEngine;

public class Loot : Interractions
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp ()
    {
        Debug.Log("Picking up " + item.name);
        bool wasCollected = Inventory.instance.AddItem(item);
        if (wasCollected)
        {
            Destroy(gameObject);
        }
    }
}
