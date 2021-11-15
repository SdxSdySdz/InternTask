using System;
using UnityEngine;

public abstract class Generator : ObjectPool
{
    [SerializeField] private PoolObject _template;

    private void Awake()
    {
        base.Init(_template);
        Init();
    }

    protected virtual void Init()
    {
    }
}
