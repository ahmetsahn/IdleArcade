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
            StartCoroutine(StartMoveDelay());
              
            GameObjectList.instance.activeLemonadeListOnTheSaleTable.RemoveAt(GameObjectList.instance.activeLemonadeListOnTheSaleTable.Count - 1);
            Debug.Log("deðdi");

        }
    }

    IEnumerator StartMoveDelay()
    {
        yield return new WaitForSeconds(0.6f);
        transform.position = startPos;
        gameObject.SetActive(false);
    }
}
