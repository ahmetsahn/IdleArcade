using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerZoneForLemon : MonoBehaviour, IInteractableWithBasket
{
    [SerializeField]
    private Transform basketTransformOnTheTable;

    [SerializeField]
    private List<GameObject> lemonadeListOnTheTable;

    [SerializeField]
    public List<GameObject> activeLemonadeListOnTheTable;

    [SerializeField]
    private int lemonadeCount;

    public void InteractWithBasket(Basket basket)
    {
        GameEvents.LoadTriggerTable();
        basket.transform.DOMove(basketTransformOnTheTable.position, 1f).onComplete += () =>
        SetActiveLemonade();
    }

    private void SetActiveLemonade()
    {
        
        
        lemonadeCount = activeLemonadeListOnTheTable.Count;

        for (int i = lemonadeCount; i < lemonadeCount + GameObjectList.instance.lemonListInBasket.Count - 1; i++)
        {
            lemonadeListOnTheTable[i].SetActive(true);
            activeLemonadeListOnTheTable.Add(lemonadeListOnTheTable[i]);
        }

    }

    
}
