using UnityEngine;

public class Loot : Interractions
{
    public Item item;
    public GameObject playerAnimation;

    public override void Interact()
    {
        base.Interact();
        
        PickUp();
    }

    void PickUp ()
    {
        Debug.Log("Picking up " + item.name);
        playerAnimation = GameObject.Find("Player");
        playerAnimation.GetComponent<Animator>().SetTrigger("Pickup");
        bool wasCollected = Inventory.instance.AddItem(item);
        if (wasCollected)
        {
            Destroy(gameObject);
        }
    }

}
