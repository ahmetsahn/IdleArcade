using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemonade : MonoBehaviour
{
    private Vector3 startPos;

    private void OnEnable() => AddListeners();

    private void OnDisable() => RemoveListeners();

    private void Start()
    {
        startPos = transform.position;
    }

    private void SetTransformStartPos()
    {
        transform.position = startPos;
    }

    private void RetryLemonades()
    {      
        SetTransformStartPos();
        transform.SetParent(null);
        gameObject.SetActive(false);
    }

    private void AddListeners()
    {
        GameEvents.OnRetryLemonades += RetryLemonades;
    }

    private void RemoveListeners()
    {
        GameEvents.OnRetryLemonades -= RetryLemonades;
    }

}
