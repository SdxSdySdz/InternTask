using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public int CoinCount { get; private set; }

    public Wallet()
    {
        CoinCount = 0;
    }

    public void AddCoin()
    {
        CoinCount++;
    }
}
