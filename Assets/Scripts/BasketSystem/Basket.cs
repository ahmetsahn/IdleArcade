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

    public List<GameObject> lemonListInBasket = new List<GameObject>();

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
            other.gameObject.GetComponent<IInteractableWithBasket>().InteractWithPlayer();
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


    private void BasketSetTransformOnTheTable()
    {
        transform.DOMove(basketTransformOnTheTable.position, 1f).onComplete += () =>
        StartCoroutine(Wait());
    }

    private void SetParentNull()
    {
        gameObject.transform.SetParent(null);
    }
    
  
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        SetParentPlayer();
        SetTransformStartPos();
        BasketComponentSetDeactive();
        GameEvents.LoadRetryLemons();  
        RemoveStackList();
    }

    private void RemoveStackList()
    {
        for (int i = lemonListInBasket.Count - 1; i > 0; i--)
        {
            lemonListInBasket.RemoveAt(i);
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
        lemonListInBasket.Add(lemon.gameObject);
    }

    private void SetStackPosition(Lemon lemon)
    {
        lemon.transform.localPosition = new Vector3(0, lemonListInBasket[lemonListInBasket.Count - 1].transform.localPosition.y + 0.72f, 0);
    }

    private void SetParentStackPoint(Lemon lemon)
    {
        lemon.transform.SetParent(lemonListInBasket[0].transform);
    }

    private void TriggerTable()
    {
        BasketSetTransformOnTheTable();
        SetParentNull();
    }

    
    private void AddListeners()
    {
        GameEvents.OnBasketComponentSetActive += BasketComponentSetActive;
        GameEvents.OnStackLemons += AddLemonToTheList;
        GameEvents.OnTriggerTable += TriggerTable;
    }

    private void RemoveListeners()
    {
        GameEvents.OnBasketComponentSetActive -= BasketComponentSetActive;
        GameEvents.OnStackLemons -= AddLemonToTheList;
        GameEvents.OnTriggerTable -= TriggerTable;
    }

}
