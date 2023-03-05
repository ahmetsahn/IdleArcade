using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Customer : MonoBehaviour
{
    public CustomerMovement customerMovement;
    public CustomerAnimation customerAnimation;

    [SerializeField]
    private Transform startPos;

    [SerializeField]
    private GameObject lemonadeImage;


    private void Update()
    {
        customerMovement.Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractableWýthCustomer>() != null)
        {
            other.gameObject.GetComponent<IInteractableWýthCustomer>().InteractWithCustomer(this);
        }
    }

    public void SetTransformStartPos()
    {
        transform.position = startPos.transform.position;
    }

    public void SetActiveLemonadeImage()
    {
        lemonadeImage.SetActive(true);
    }

    public void SetDeactiveLemonadeImage()
    {
        lemonadeImage.SetActive(false);
    }


}
