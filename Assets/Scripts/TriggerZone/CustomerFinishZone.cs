using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFinishZone : MonoBehaviour, IInteractableWýthCustomer
{
    public void InteractWithCustomer(Customer customer)
    {
        customer.SetTransformStartPos();
    }
}
