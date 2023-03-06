using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Basket : MonoBehaviour
{
    [SerializeField]
    private Transform basketTransformOnTheTable;

    private Vector3 startPos;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private BoxCollider boxCollider;

    

    private void OnEnable()
    {
        AddListeners();
    } 

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void Start()
    {
        startPos = transform.localPosition;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractableWithBasket>() != null)
        {
            other.gameObject.GetComponent<IInteractableWithBasket>().InteractWithBasket(this);
            
        }
    }

    private void BasketComponentSetActive()
    {
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
    }

    private void BasketComponentSetDeactive()
    {
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
    }


   

    private void SetParentNull()
    {
        gameObject.transform.SetParent(null);
    }

    private void RemoveStackList()
    {
        for (int i = GameObjectList.instance.lemonListInBasket.Count - 1; i > 0; i--)
        {
            GameObjectList.instance.lemonListInBasket.RemoveAt(i);
        }
    }

    private void SetTransformStartPos()
    {
        transform.localPosition = startPos;
    }

    private void SetParentPlayer()
    {
        transform.SetParent(player);
    }

    private void AddLemonToTheList(Lemon lemon)
    {
        SetParentStackPoint(lemon);
        SetStackPosition(lemon);
        AddStackList(lemon);
    }

    private void AddStackList(Lemon lemon)
    {
        GameObjectList.instance.lemonListInBasket.Add(lemon.gameObject);
    }

    private void SetStackPosition(Lemon lemon)
    {
        lemon.transform.localPosition = new Vector3(0, GameObjectList.instance.lemonListInBasket[GameObjectList.instance.lemonListInBasket.Count - 1].transform.localPosition.y + 0.72f, 0);
    }

    private void SetParentStackPoint(Lemon lemon)
    {
        lemon.transform.SetParent(GameObjectList.instance.lemonListInBasket[0].transform);
    }

    private void TriggerTable()
    {
        StartCoroutine(Wait());
        SetParentNull();
    }

    private void SetActiveLemonade()
    {
        GameObjectList.instance.activeLemonadeOnTheTableCount = GameObjectList.instance.activeLemonadeListOnTheTable.Count;

        for (int i = GameObjectList.instance.activeLemonadeOnTheTableCount; i < GameObjectList.instance.activeLemonadeOnTheTableCount + GameObjectList.instance.lemonListInBasket.Count-1; i++)
        {
            GameObjectList.instance.lemonadeListOnTheTable[i].SetActive(true);
            GameObjectList.instance.activeLemonadeListOnTheTable.Add(GameObjectList.instance.lemonadeListOnTheTable[i]);
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SetParentPlayer();
        SetTransformStartPos();
        BasketComponentSetDeactive();
        GameEvents.LoadRetryLemons();
        SetActiveLemonade();
        RemoveStackList();
    }

    private void AddListeners()
    {
        GameEvents.OnBasketComponentSetActive += BasketComponentSetActive;
        GameEvents.OnStackLemons += AddLemonToTheList;
        GameEvents.OnTriggerReleaseLemonZone += TriggerTable;
    }

    private void RemoveListeners()
    {
        GameEvents.OnBasketComponentSetActive -= BasketComponentSetActive;
        GameEvents.OnStackLemons -= AddLemonToTheList;
        GameEvents.OnTriggerReleaseLemonZone -= TriggerTable;
    }

}
