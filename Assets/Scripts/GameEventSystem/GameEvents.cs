using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityAction OnTriggerTree;
    public static UnityAction OnBasketComponentSetActive;
    public static UnityAction OnTriggerReleaseLemonZone;
    public static UnityAction OnTriggerTakeLemonadeZone;
    public static UnityAction OnTriggerSaleZone;
    public static UnityAction<Lemon> OnStackLemons;
    public static UnityAction OnRetryLemons;
    public static UnityAction OnRetryLemonades;
    
    
   



    public static void LoadTriggerTree()
    {
        OnTriggerTree?.Invoke();
    }

    public static void LoadBasketComponentSetActive()
    {
        OnBasketComponentSetActive?.Invoke();
    }

    public static void LoadTriggerTable()
    {
        OnTriggerReleaseLemonZone?.Invoke();
    }

    public static void LoadTriggerSaleZone()
    {
        OnTriggerSaleZone?.Invoke();
    }


    public static void LoadStackLemons(Lemon lemon)
    {
        OnStackLemons?.Invoke(lemon);
    }


    public static void LoadRetryLemons()
    {
        OnRetryLemons?.Invoke();
    }

    public static void LoadTriggerTakeLemonadeZone()
    {
        OnTriggerTakeLemonadeZone?.Invoke(); 
    }

    public static void LoadRetryLemonades()
    {
        OnRetryLemonades?.Invoke();
    }

}
