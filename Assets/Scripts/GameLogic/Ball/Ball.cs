using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallJumper))]
[RequireComponent(typeof(SphereCollider))]
public class Ball : MonoBehaviour
{
    public BallJumper Jumper { get; private set; }

    public event UnityAction CoinCollided;

    private void Awake()
    {
        Jumper = GetComponent<BallJumper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            CoinCollided?.Invoke();
        }
        else if (other.TryGetComponent(out Obstacle obstacle))
        {
            
        }
    }
}
