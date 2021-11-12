using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ObstaclePart : MonoBehaviour, IPlayerKiller
{
    private BoxCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
    }
}
