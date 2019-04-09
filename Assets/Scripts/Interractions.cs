using UnityEngine;

public class Interractions : MonoBehaviour
{
    public float radius = 3f;
    public Transform interaction;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log ("Interracting with " + transform.name);
    }

    void Update() 
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interaction.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }    
    }
    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OffFocused ()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected() 
    {
        if (interaction == null)
        {
            interaction = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interaction.position, radius);
    }


}
