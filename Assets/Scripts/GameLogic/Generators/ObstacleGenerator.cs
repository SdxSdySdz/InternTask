using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleGenerator : TimerBasedGenerator
{
    [SerializeField] private Vector2 _spawnHeightRange;

    private void Start()
    {
        if (_spawnHeightRange.x >= _spawnHeightRange.y)
            throw new Exception("Incorrect spawn range");
    }

    protected void Spawn(PoolObject obstacle, float height)
    {
        
        Vector3 spawnPoint = Container.transform.position + Container.transform.up * height;
        obstacle.Show();
        obstacle.transform.position = spawnPoint;
    }
    
    protected override void OnTimerTicked()
    {
        float randomHeight = Random.Range(_spawnHeightRange.x, _spawnHeightRange.y);

        if (TryGetObject(out PoolObject poolObject))
        {
            Spawn(poolObject, randomHeight);
            HideObjectsBehindTheScreen();
        }
        else
            CancelLastTick();
    }
    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        DrawSpawnRange();
    }

    private void DrawSpawnRange()
    {
        Vector3 lowPosition = Container.transform.position + Container.transform.up * _spawnHeightRange.x;
        Vector3 highPosition = Container.transform.position + Container.transform.up * _spawnHeightRange.y;
        
        Gizmos.DrawLine(lowPosition, highPosition);
    }
#endif
}
