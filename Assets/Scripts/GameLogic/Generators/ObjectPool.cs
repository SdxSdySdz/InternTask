using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool: MonoBehaviour 
{
    [SerializeField] private int _capacity;
    [SerializeField] protected Transform Container;

    private Camera _camera;
    private List<GameObject> _pool = new List<GameObject>();

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
        }
    }
    
    protected void Init(GameObject prefab)
    {
        _camera = Camera.main;
        
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, Container);
            spawnedObject.SetActive(false);
            
            _pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectsBehindTheScreen()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf)
            {
                Vector3 point = _camera.WorldToScreenPoint(item.transform.position);
                if (point.x < 0)
                    item.SetActive(false);
            }
        }
    }
}
