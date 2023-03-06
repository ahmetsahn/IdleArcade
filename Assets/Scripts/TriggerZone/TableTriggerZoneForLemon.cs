using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerZoneForLemon : MonoBehaviour, IInteractableWithBasket
{
    [SerializeField]
    private Transform basketTransformOnTheTable;

    public void InteractWithBasket(Basket basket)
    {
        basket.transform.DOMove(basketTransformOnTheTable.position, 1f).onComplete += () =>
        GameEvents.LoadTriggerTable();
    }
}
