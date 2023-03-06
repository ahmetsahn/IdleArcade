using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectZone : MonoBehaviour, IInteractableWithPlayer
{
    [SerializeField]
    private UIController uiController;
    
    public void InteractWithPlayer(Player player)
    {
        if(GameObjectList.instance.activeMoneyListOnTheSaleTable.Count>0)
        {
            Debug.Log("Money collected");
            GameEvents.LoadMoneyMoveToPlayer(player);
            uiController.IncreamentMoney(GameObjectList.instance.activeMoneyListOnTheSaleTable.Count);
            GameObjectList.instance.activeMoneyListOnTheSaleTable.Clear();
            
        }
       
    }
}
