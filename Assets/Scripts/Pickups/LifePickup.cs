using UnityEngine;

public class LifePickup : Pickup
{
    protected override void ApplyEffect(Collider player)
    {
        player.GetComponent<PlayerHealth>()?.GainLife();
    }
}
