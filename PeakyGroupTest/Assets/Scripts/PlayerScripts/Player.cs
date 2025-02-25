using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerHealth health;

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        
        if(interactable != null)
        {
            interactable.Interact(this);
        }
    }
}
