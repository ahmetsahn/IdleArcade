using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SaleZoneTrigger : MonoBehaviour, IInteractableWithPlayer
{
    
    


    [SerializeField]
    private Transform saleTable;
    public void InteractWithPlayer()
    {

        foreach (GameObject gameObject in GameObjectList.instance.lemonadeOnThePlayer)
        {
        
                gameObject.transform.SetParent(saleTable);     
                gameObject.transform.localPosition = new Vector3(GameObjectList.instance.lemonadeOnTheSaleTable[GameObjectList.instance.lemonadeOnTheSaleTable.Count - 1].transform.localPosition.x + 0.2f, 0.9f , -0.5f);
                GameObjectList.instance.lemonadeOnTheSaleTable.Add(gameObject);
        }

        GameObjectList.instance.lemonadeOnThePlayer.Clear();

    }
}
