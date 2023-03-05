using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using DG.Tweening;

public class SaleZoneTrigger : MonoBehaviour, IInteractableWithPlayer
{
    
    


    [SerializeField]
    private Transform saleTable;
    public void InteractWithPlayer()
    {

        GameEvents.LoadRetryLemonades();

        for (int i = 0; i < GameObjectList.instance.lemonadeListOnThePlayer.Count; i++)
        {
            GameObjectList.instance.lemonadeListOnTheSaleTable[i].SetActive(true);
        }

        GameObjectList.instance.lemonadeListOnThePlayer.Clear();

    }
}
