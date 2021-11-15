using UnityEngine;

public abstract class TimerBasedGenerator : Generator
{
    [SerializeField] private Timer _timer;
    
    private void OnEnable()
    {
        _timer.Tick += OnTimerTicked;
    }

    private void OnDisable()
    {
        _timer.Tick -= OnTimerTicked;
    }

    protected abstract void OnTimerTicked();

    protected void CancelLastTick()
    {
        _timer.CancelLastTick();
    }
}
        
