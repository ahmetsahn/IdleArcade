using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStopZoneControl : MonoBehaviour
{
    
    PlayerController playerController;
    GameManager gameManager;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
       gameManager.moneyStackNumber = -1;
    }

    private void Update()
    {
        if(gameManager.takeMoney)
        {
           gameManager.moneyStackNumber = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Customer")&& gameManager.saleZoneLemonadeCount>0)
        {
           gameManager.moneyStackNumber++;
        }
        
    }
}
