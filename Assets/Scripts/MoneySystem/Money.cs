using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Money : MonoBehaviour
{
    private Vector3 startPos;

    private void OnEnable() => AddListeners();

    private void OnDisable() => RemoveListeners();

    private void Start()
    {
        startPos = transform.position;
    }

    private void MoveToPlayer(Player player)
    {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        transform.DOMove(targetPos, 0.5f).onComplete += () =>
        transform.DOMove(startPos, 0).onComplete += () =>
        gameObject.SetActive(false);

       
    }

    private void AddListeners()
    {
        GameEvents.OnMoneyMoveToPlayer += MoveToPlayer;
    }

    private void RemoveListeners()
    {
        GameEvents.OnMoneyMoveToPlayer -= MoveToPlayer;
    }

    
}
