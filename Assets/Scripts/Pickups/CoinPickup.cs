using UnityEngine;

public class CoinPickup : Pickup
{
    protected override void ApplyEffect(Collider player)
    {
        player.GetComponent<PlayerScore>()?.AddScore();
    }
}
