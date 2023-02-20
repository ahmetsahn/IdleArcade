using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, IInteractableWithBasket
{
    
    public void InteractWithPlayer()
    {
        GameEvents.LoadTriggerTable();
    }

    

    
}
