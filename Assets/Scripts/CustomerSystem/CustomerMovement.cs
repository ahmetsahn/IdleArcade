using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerMovement : MonoBehaviour
{
    private float movementSpeed = 2;

   
    public void Move()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    public void StopMove()
    {
        movementSpeed = 0;
    }

    public void StartMove()
    {
        movementSpeed = 2;
    }

    public void SetRotation()
    {
        transform.DORotate(new Vector3(0, 360, 0), 1f);
    }

    public void SetRotationStartRotate()
    {
        transform.DORotate(new Vector3(0, 270, 0), 1f);
    }

   

   

}
