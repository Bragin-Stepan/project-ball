using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public List<Coin> Coins;

    public Wallet()
    {
        Coins = new List<Coin>();
    }

    public void AddCoin(Coin coin) => Coins.Add(coin);

    public void Clear() => Coins.Clear();
}