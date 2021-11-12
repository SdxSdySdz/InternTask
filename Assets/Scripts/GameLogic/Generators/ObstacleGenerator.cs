using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleGenerator : ObjectPool
{
    [SerializeField] private Obstacle _template;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Vector2 _spawnHeightRange;

    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = 0;

        if (_spawnHeightRange.x >= _spawnHeightRange.y)
            throw new Exception("Incorrect spawn range");

        Init(_template.gameObject);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject obstacle))
            {
                _elapsedTime = 0;

                Spawn(obstacle);
                DisableObjectsBehindTheScreen();
            }
        }
    }

    private void Spawn(GameObject obstacle)
    {
        float randomHeight = Random.Range(_spawnHeightRange.x, _spawnHeightRange.y);
        Vector3 spawnPoint = Container.transform.position + Container.transform.up * randomHeight;
        obstacle.SetActive(true);
        obstacle.transform.position = spawnPoint;
    }

    private void OnDrawGizmos()
    {
        Vector3 disablePoint = Camera.main.ViewportToWorldPoint(new Vector2(0, .5f));
        Gizmos.DrawSphere(disablePoint, 1);
        
        DrawSpawnRange();
    }

    private void DrawSpawnRange()
    {
        Vector3 lowPosition = Container.transform.position + Container.transform.up * _spawnHeightRange.x;
        Vector3 highPosition = Container.transform.position + Container.transform.up * _spawnHeightRange.y;
        
        Gizmos.DrawLine(lowPosition, highPosition);
        
        
        
    }
}
