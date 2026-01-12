using UnityEngine;

public class CoinPickup : Pickup
{
    protected override void ApplyEffect(Collider other)
    {
        if (!other.TryGetComponent(out IRewardable rewardable)) return;

        rewardable.AddScore();
    }
}
