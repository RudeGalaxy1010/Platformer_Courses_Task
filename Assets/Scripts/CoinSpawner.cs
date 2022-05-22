using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _coinSpawnPoints;
    [SerializeField] private ScoreController _scoreController;

    private void Start()
    {
        for (int i = 0; i < _coinSpawnPoints.Length; i++)
        {
            Coin coin = Instantiate(_coinPrefab, _coinSpawnPoints[i].position, Quaternion.identity);
            coin.Init(_scoreController);
        }
    }
}
