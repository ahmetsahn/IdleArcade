using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerZoneForLemonade : MonoBehaviour, IInteractableWithPlayer
{
   

    
    public void InteractWithPlayer(Player player)
    {
        
        foreach (GameObject gameObject in GameObjectList.instance.activeLemonadeListOnTheTable)
        {
                gameObject.transform.SetParent(player.transform);
                GameObjectList.instance.lemonadeListOnThePlayer.Add(gameObject);
        }

        GameObjectList.instance.activeLemonadeListOnTheTable.Clear();


    }
}
