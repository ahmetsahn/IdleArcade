using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonadeOnTheSaleTable : MonoBehaviour
{
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Customer"))
        {
            gameObject.SetActive(false);
            gameObject.transform.position = startPos;
            GameObjectList.instance.activeLemonadeListOnTheSaleTable.RemoveAt(GameObjectList.instance.activeLemonadeListOnTheSaleTable.Count - 1);

        }
    }
}
