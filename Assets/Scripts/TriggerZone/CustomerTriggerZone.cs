using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerTriggerZone : MonoBehaviour, IInteractableWýthCustomer
{
    public void InteractWithCustomer(Customer customer)
    {
        
        
        if (GameObjectList.instance.activeLemonadeListOnTheSaleTable.Count > 0)
        {
            customer.customerMovement.StopMove();
            customer.customerAnimation.StopWalk();
            customer.customerMovement.SetRotation();
            customer.SetDeactiveLemonadeImage();

            GameObjectList.instance.activeMoneyOnTheSaleTableCount = GameObjectList.instance.activeMoneyListOnTheSaleTable.Count;
            GameObjectList.instance.activeMoneyListOnTheSaleTable.Add(GameObjectList.instance.moneyListOnTheSaleTable[GameObjectList.instance.activeMoneyOnTheSaleTableCount]);
            GameObjectList.instance.activeLemonadeListOnTheSaleTable[^1].gameObject.transform.DOMove(customer.transform.position, 1f).onComplete += () =>
            GameObjectList.instance.activeMoneyListOnTheSaleTable[^1].SetActive(true);
            
           StartCoroutine(StartMoveDelay(customer));

        }
    }

    IEnumerator StartMoveDelay(Customer customer)
    {
        yield return new WaitForSeconds(1f);
        customer.customerMovement.SetRotationStartRotate();
        yield return new WaitForSeconds(1f);
        customer.customerAnimation.StartWalk();
        customer.customerMovement.StartMove();
        
        
    }
   
}
