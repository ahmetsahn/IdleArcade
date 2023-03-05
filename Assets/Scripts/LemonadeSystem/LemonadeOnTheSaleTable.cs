using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeOnTheSaleTable : MonoBehaviour
{
    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            transform.position = startPos;
            gameObject.SetActive(false);   
            GameObjectList.instance.activeLemonadeListOnTheSaleTable.RemoveAt(GameObjectList.instance.activeLemonadeListOnTheSaleTable.Count - 1);
            Debug.Log("deðdi");

        }
    }
}
