using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerZoneForLemonade : MonoBehaviour, IInteractableWithPlayer
{

    [SerializeField]
    private TableTriggerZoneForLemon tableTriggerZoneForLemon;

    public void InteractWithPlayer(Player player)
    {
        
        foreach (GameObject gameObject in tableTriggerZoneForLemon.activeLemonadeListOnTheTable)
        {
                gameObject.transform.SetParent(player.transform);
                GameObjectList.instance.lemonadeListOnThePlayer.Add(gameObject);
        }

        tableTriggerZoneForLemon.activeLemonadeListOnTheTable.Clear();


    }
}
