using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    
    private Wallet _wallet;

    public int CoinCount => _wallet.CoinCount;
    
    public event UnityAction CoinPickedUp;

    private void Awake()
    {
        _wallet = new Wallet();
    }

    private void OnEnable()
    {
        _ball.CoinCollided += OnCoinCollided;
    }

    private void OnDisable()
    {
        _ball.CoinCollided -= OnCoinCollided;
    }

    private void OnCoinCollided()
    {
        _wallet.AddCoin();
        CoinPickedUp?.Invoke();
    }
}
