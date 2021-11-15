using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool: MonoBehaviour 
{
    [SerializeField] private int _capacity;
    
    [SerializeField] protected Transform Container;

    private Camera _camera;
    private  List<PoolObject> _pool = new List<PoolObject>();

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
        }
    }

    protected void Init(PoolObject prefab)
    {
        _camera = Camera.main;
        
        for (int i = 0; i < _capacity; i++)
        {
            SpawnPrefab(prefab);
        }
    }

    protected bool TryGetObjects(int count, out PoolObject[] result)
    {
        var candidates = _pool.Where(item => item.gameObject.activeSelf == false);
        if (candidates.Count() < count)
        {
            result = null;
            return false;
        }

        result = candidates.Take(count).ToArray();
        return true;
    }
    
    protected bool TryGetObject(out PoolObject result)
    {
        result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        return result != null;
    }

    protected void HideObjectsBehindTheScreen()
    {
        foreach (var item in _pool)
        {
            if (item.IsHidden == false)
            {
                Vector3 point = _camera.WorldToScreenPoint(item.transform.position);
                if (point.x < 0)
                    item.Hide();
            }
        }
    }
    
    private void SpawnPrefab(PoolObject prefab)
    {
        PoolObject spawnedObject = Instantiate(prefab, Container);
        spawnedObject.Hide();
        
        _pool.Add(spawnedObject);
    }
}
