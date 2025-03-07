using UnityEngine;

public class Damage : Interactable
{
    public int damageAmount = 10;
    public override void Interact(Player player)
    {
        player.health.TakeDamage(damageAmount);

        ItemSaver.Instance.ItemPickup(gameObject.name);

        Destroy(gameObject);
    }
}
