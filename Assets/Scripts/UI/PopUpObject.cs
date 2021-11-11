using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpObject : MonoBehaviour
{
    [SerializeField] private RectTransform _hiddenPosition;
    [SerializeField] private RectTransform _popedUpPosition;
    [SerializeField] private float _speed;

    private Coroutine _translationCoroutine;
    
    private void Awake()
    {
        transform.position = _hiddenPosition.position;
    }

    public void PopUp()
    {
        ProvideTranslation(_popedUpPosition);
    }

    public void Hide()
    {
        ProvideTranslation(_hiddenPosition);
    }

    private void ProvideTranslation(RectTransform target)
    {
        if (_translationCoroutine != null)
            StopCoroutine(_translationCoroutine);

        _translationCoroutine = StartCoroutine(Translate(target));
    }

    private IEnumerator Translate(RectTransform target)
    {
        var waitForEndOfFrame = new WaitForEndOfFrame();
        
        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, 
                target.position, 
                _speed * Time.deltaTime
                );
            yield return waitForEndOfFrame;
        }
    }
}