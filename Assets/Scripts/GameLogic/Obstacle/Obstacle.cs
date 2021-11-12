using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _speed;

    private void Start()
    {
        _moveDirection = _moveDirection.normalized;
        transform.LookAt(transform.position + _moveDirection);
    }

    private void Update()
    {
        transform.position += _moveDirection * (_speed * Time.deltaTime);
    }
}
