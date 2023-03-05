using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectList : MonoBehaviour
{
    public static GameObjectList instance;

    public List<GameObject> lemonListInBasket = new List<GameObject>();

    public List<GameObject> lemonadeListOnTheTable = new List<GameObject>();

    public List<GameObject> activeLemonadeListOnTheTable = new List<GameObject>();

    public List<GameObject> lemonadeListOnThePlayer = new List<GameObject>();

    public List<GameObject> lemonadeListOnTheSaleTable = new List<GameObject>();
    
    public List<GameObject> activeLemonadeListOnTheSaleTable = new List<GameObject>();
    
    

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
