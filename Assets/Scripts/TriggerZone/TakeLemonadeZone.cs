using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLemonadeZone : MonoBehaviour, IInteractableWithPlayer
{
   
    public  GameObject[] lemonade;

    [SerializeField]
    private Transform player;
    public void InteractWithPlayer()
    {
        Debug.Log("Take Lemonade");
        foreach (GameObject gameObject in lemonade)
        {
            if (gameObject.activeSelf)
            {
                gameObject.transform.SetParent(player);
            }
            
        }
    }
}
