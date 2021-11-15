using System;
using TMPro;
using UnityEngine;

public class WalletViewer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        OnCoinPickedUp();
    }

    private void OnEnable()
    {
        _player.CoinPickedUp += OnCoinPickedUp;
    }

    private void OnDisable()
    {
        _player.CoinPickedUp -= OnCoinPickedUp;
    }

    private void OnCoinPickedUp()
    {
        _text.text = _player.CoinCount.ToString();
    }
}
