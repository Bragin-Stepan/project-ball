using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private List<Coin> _coins = new List<Coin>();

    public int CoinsCount => _coins.Count;

    public void AddCoin(Coin coin) => _coins.Add(coin);

    public void Clear() => _coins.Clear();
}