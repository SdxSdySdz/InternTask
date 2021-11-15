using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallJumper))]
[RequireComponent(typeof(SphereCollider))]
public class Ball : MonoBehaviour
{
    public event UnityAction CoinCollided;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.Disappear();
            CoinCollided?.Invoke();
        }
        else if (other.TryGetComponent(out IPlayerKiller _))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
