using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public CustomerMovement customerMovement;
    public CustomerAnimation customerAnimation;

    [SerializeField]
    private Transform startPos;


    private void Update()
    {
        customerMovement.Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractableW�thCustomer>() != null)
        {
            other.gameObject.GetComponent<IInteractableW�thCustomer>().InteractWithCustomer(this);
        }
    }

    public void SetTransformStartPos()
    {
        transform.position = startPos.transform.position;
    }

   
}