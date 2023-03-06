using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using DG.Tweening;

public class SaleZoneTrigger : MonoBehaviour, IInteractableWithPlayer
{
 
    [SerializeField]
    private Transform saleTable;
    public void InteractWithPlayer(Player player)
    {
        if(GameObjectList.instance.lemonadeListOnThePlayer.Count > 0)
        {
            GameEvents.LoadRetryLemonades();

            GameObjectList.instance.activeLemonadeOnTheSaleTableCount = GameObjectList.instance.activeLemonadeListOnTheSaleTable.Count;

            for (int i = GameObjectList.instance.activeLemonadeOnTheSaleTableCount; i < GameObjectList.instance.activeLemonadeOnTheSaleTableCount + GameObjectList.instance.lemonadeListOnThePlayer.Count; i++)
            {
                GameObjectList.instance.lemonadeListOnTheSaleTable[i].SetActive(true);
                GameObjectList.instance.activeLemonadeListOnTheSaleTable.Add(GameObjectList.instance.lemonadeListOnTheSaleTable[i]);
            }

            GameObjectList.instance.lemonadeListOnThePlayer.Clear();
        }

    }
}
