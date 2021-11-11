using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _rigidbody.useGravity = false;
        _rigidbody.freezeRotation = true;
    }

    public void Jump()
    {
    }
}
