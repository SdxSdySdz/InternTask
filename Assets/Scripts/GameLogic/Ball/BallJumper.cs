using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.useGravity = true;
        _rigidbody.freezeRotation = true;
    }

    public void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Acceleration);
    }
}
