using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTriggerZoneForLemon : MonoBehaviour, IInteractableWithBasket
{    
    public void InteractWithBasket()
    {
        GameEvents.LoadTriggerTable();
    }
}
