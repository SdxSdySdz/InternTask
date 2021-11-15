using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _period;
    
    private float _elapsedTime;

    public event UnityAction Tick;

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _period)
        {
            Tick?.Invoke();
            _elapsedTime = 0;
        }
    }

    public void CancelLastTick()
    {
        _elapsedTime = _period + 1;
    }
    
    private void ResetTimer()
    {
        _elapsedTime = 0;
    }
}
