using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFinishZone : MonoBehaviour, IInteractableW�thCustomer
{
    public void InteractWithCustomer(Customer customer)
    {
        customer.SetTransformStartPos();
    }
}
