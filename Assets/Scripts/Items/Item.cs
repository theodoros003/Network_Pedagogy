using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isNote = false;
    [TextArea(5, 10)]
    public string noteContent;
    public string message;

    public virtual void Use()
    {
        message = "You have successfully added the " + name;
        Debug.Log("Using " + name);
    }

}
