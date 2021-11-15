using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public bool IsHidden => gameObject.activeSelf == false;

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Disappear()
    {
        OnDisappeared();
        Hide();
    }
    
    protected virtual void OnDisappeared()
    {
    }
}

