using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.gameObject.GetComponent<Coin>();

        if (coin)
            PickUpCoin(coin);
    }

    private void PickUpCoin(Coin coin)
    {
        _wallet.AddCoin(coin);
        coin.PickUp();
    }
}