using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectZone : MonoBehaviour, IInteractableWithPlayer
{
    public void InteractWithPlayer(Player player)
    {
        if(GameObjectList.instance.activeMoneyListOnTheSaleTable.Count>0)
        {
             Debug.Log("Money collected");
        }
       
    }
}
