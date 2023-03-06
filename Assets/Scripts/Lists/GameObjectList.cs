using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectList : MonoBehaviour
{
    public static GameObjectList instance;

    public List<GameObject> lemonListInBasket = new List<GameObject>();

    public List<GameObject> lemonadeListOnThePlayer = new List<GameObject>();

    public List<GameObject> lemonadeListOnTheSaleTable = new List<GameObject>();
    
    public List<GameObject> activeLemonadeListOnTheSaleTable = new List<GameObject>();
    
    public List<GameObject> moneyListOnTheSaleTable = new List<GameObject>();

    public List<GameObject> activeMoneyListOnTheSaleTable = new List<GameObject>();

    public int activeLemonadeOnTheSaleTableCount { get; set; }
    
    



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
