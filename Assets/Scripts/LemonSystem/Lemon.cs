using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lemon : MonoBehaviour, IInteractableWithPlayer
{
    
    private Vector3 startPos;

    [SerializeField]
    private CapsuleCollider capsuleCollider;

    [SerializeField]
    private Rigidbody rigidbody;

    private void OnEnable() => AddListeners();

    private void OnDisable() => RemoveListeners();






    private void Start()
    {
        startPos = transform.position;
    }




    public void InteractWithPlayer()
    {
        GameEvents.LoadBasketComponentSetActive();
        GameEvents.LoadStackLemons(this);
        SetContraintsFreeze();
        SetColliderDeactive();
    }

    private void SetColliderDeactive()
    {
        capsuleCollider.enabled = false;
    }
    private void SetColliderActive()
    {
        capsuleCollider.enabled = true;

    }
   
    private void SetContraintsFreeze()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void SetContraintYFalse()
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }

    private void SetGravityDeactive()
    {
        rigidbody.useGravity = false;
    }

    private void SetParentNull()
    {
        transform.SetParent(null);
    }

    private void SetTransformStartPos()
    {
        transform.position = startPos;
    }



    private void RetryLemons()
    {
        SetParentNull();
        SetTransformStartPos();
        SetContraintYFalse();
        SetGravityDeactive();
        SetColliderActive();
    }

    

    private void AddListeners()
    {
        GameEvents.OnRetryLemons += RetryLemons;
    }

    private void RemoveListeners()
    {
        GameEvents.OnRetryLemons -= RetryLemons;
    }

}
