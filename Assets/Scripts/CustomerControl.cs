using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
    
    private PlayerController playerController;
    private CustomerStopZoneControl customerStopZoneControl;
    private GameManager gameManager;
    private Animator customerAnim;
    [SerializeField] private GameObject lemonImage;
    private int customerMoveSpeed = 2;
    private bool hereSaleZone;


    private void Start()
    {
        customerAnim = gameObject.GetComponent<Animator>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        customerStopZoneControl = GameObject.Find("CustomerStopZone").GetComponent<CustomerStopZoneControl>();
        hereSaleZone = false;
    }


    private void Update()
    {
        if(transform.position.x<=-17)
        {
            transform.position = new Vector3(24, transform.position.y, transform.position.z);
            lemonImage.SetActive(true);
        }
    }



    private void FixedUpdate()
    {
        if(hereSaleZone == false)
        {
            transform.Translate(Vector3.forward * customerMoveSpeed * Time.deltaTime);
            customerAnim.SetBool("Idle", false);
        }
        else
        {
            customerAnim.SetBool("Idle", true);
            
        }

        
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CustomerStopZone") && gameManager.saleZoneLemonadeCount>0)
        {
            hereSaleZone = true;
            


            StartCoroutine(SaleZone());
        }
    }


    IEnumerator SaleZone()
    {
       
        
        transform.rotation = Quaternion.Euler(transform.rotation.x, 350, transform.rotation.z);
        lemonImage.transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        
        yield return new WaitForSeconds(2);
        
        gameManager.money[gameManager.moneyStackNumber].SetActive(true);
        gameManager.saleZoneLemonadeArray[gameManager.saleZoneLemonadeCount-1].SetActive(false);
        gameManager.saleZoneLemonadeCount--;
        



        lemonImage.SetActive(false);
        hereSaleZone = false;
        transform.rotation = Quaternion.Euler(transform.rotation.x, 270, transform.rotation.z);

    }
}
