using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerZoneForLemonade : MonoBehaviour, IInteractableWithPlayer
{
   

    [SerializeField]
    private Transform player;
    public void InteractWithPlayer()
    {
        
        foreach (GameObject gameObject in GameObjectList.instance.activeLemonadeListInTable)
        {
                gameObject.transform.SetParent(player);
                GameObjectList.instance.lemonadeOnThePlayer.Add(gameObject);
            
        }

        GameObjectList.instance.activeLemonadeListInTable.Clear();
    }
}
