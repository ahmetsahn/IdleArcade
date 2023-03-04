using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectList : MonoBehaviour
{
    public static GameObjectList instance;

    public List<GameObject> lemonListInBasket = new List<GameObject>();

    public List<GameObject> activeLemonadeListInTable = new List<GameObject>();

    public List<GameObject> lemonadeOnThePlayer = new List<GameObject>();

    public List<GameObject> lemonadeOnTheSaleTable = new List<GameObject>();
    
    public List<GameObject> lemonadeOnTheTable = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
