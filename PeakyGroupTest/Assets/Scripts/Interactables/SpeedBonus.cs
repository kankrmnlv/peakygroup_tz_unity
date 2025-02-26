using UnityEngine;

public class SpeedBonus : Interactable
{
    public float speedMultiplier;
    public float duration;
    public override void Interact(Player player)
    {
        player.movement.ApplySpeedBoost(speedMultiplier, duration);

        ItemSaver.Instance.ItemPickup(gameObject.name);

        Destroy(gameObject);
    }
}
