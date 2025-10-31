using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private List<Coin> _coins;
    [SerializeField] private float _timeToWin;
    [SerializeField] private bool _showDebugGui;

    private bool _isGameOver;
    private float _currentTime;

    private void Start()
    {
        Restart();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Restart();

        if (_isGameOver)
            return;

        GameProcess();
    }

    private void Restart()
    {
        _isGameOver = false;
        _currentTime = 0;

        PlayerInit();

        foreach (Coin coin in _coins)
            coin.gameObject.On();
    }

    private void GameProcess()
    {
        if (_currentTime >= _timeToWin)
            Lose();

        if (_coins.Count <= _player.Wallet.CoinsCount)
            Win();

        _currentTime += Time.deltaTime;
    }

    private void PlayerInit()
    {
        _player.gameObject.On();
        _player.Wallet.Clear();
        _player.Unfreeze();
        _player.Teleport(_playerSpawnPoint.position);
    }

    private void Lose()
    {
        _isGameOver = true;

        _player.Teleport(_playerSpawnPoint.position);
        _player.Freeze();

        Debug.Log("You lose");
    }

    private void Win()
    {
        _isGameOver = true;
        Debug.Log("You win!");
    }

    public void OnGUI()
    {
        if (_showDebugGui)
        {
            GUI.Label(new Rect(20, 20, 200, 20), "До порожения: " + (_timeToWin - _currentTime));
            GUI.Label(new Rect(20, 40, 200, 20), "Монет собрано: " + _player.Wallet.CoinsCount + "/" + _coins.Count);
        }
    }
}
