using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFinishZone : MonoBehaviour, IInteractableWęthCustomer
{
    public void InteractWithCustomer(Customer customer)
    {
        customer.SetTransformStartPos();
        customer.SetActiveLemonadeImage();
    }
}
