using System;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class CoinLineGenerator : TimerBasedGenerator
{
    [SerializeField] private Vector3 _lineDirection;
    [SerializeField] private Vector2Int _coinsCountRange;
    [SerializeField] private float _spaceBetween;

    private void Start()
    {
        if (_coinsCountRange.x >= _coinsCountRange.y)
            throw new Exception("Incorrect coins count range");

        if (_spaceBetween < 0)
            throw new Exception("Incorrect space between");
        
        _lineDirection = _lineDirection.normalized;
    }

    protected override void OnTimerTicked()
    {
        int randomCount = Random.Range(_coinsCountRange.x, _coinsCountRange.y + 1);

        if (TryGetObjects(randomCount, out PoolObject[] result))
        {
            SpawnCoins(result);
            HideObjectsBehindTheScreen();
        }
        else
            CancelLastTick();
    }
    
    private void SpawnCoins(PoolObject[] poolObjects)
    {
        for (int i = 0; i < poolObjects.Length; i++)
        {
            Vector3 spawnPosition = transform.position + _lineDirection * (i * (1 + _spaceBetween));
            
            poolObjects[i].Show();
            poolObjects[i].transform.position = spawnPosition;
        }
    }
}
