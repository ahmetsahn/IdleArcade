using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerZoneForLemonade : MonoBehaviour, IInteractableWithPlayer
{
   

    [SerializeField]
    private Transform player;
    public void InteractWithPlayer()
    {
        
        foreach (GameObject gameObject in GameObjectList.instance.activeLemonadeListOnTheTable)
        {
                gameObject.transform.SetParent(player);
                GameObjectList.instance.lemonadeListOnThePlayer.Add(gameObject);
            
        }

        GameObjectList.instance.activeLemonadeListOnTheTable.Clear();


    }
}
