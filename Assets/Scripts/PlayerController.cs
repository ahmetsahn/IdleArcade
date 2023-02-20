using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{
    
    
      
    
    private GameManager gameManager;
    private CustomerControl customerControl;




    private void Start()
    {
        customerControl = GameObject.FindGameObjectWithTag("Customer").GetComponent<CustomerControl>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    

   


    private void OnTriggerEnter(Collider other)
    {
        

        

        

        if (other.CompareTag("Table2"))
        {
            if (GameManager.basketActive)
            {
               gameManager.lemonadeHave = true;
               gameManager.lemonadeCount2 += GameManager.lemonCount;
                
               GameManager.lemonCount -=gameManager.lemonList.Count - 1;
               GameManager.basket.transform.parent = null;
               GameManager.basket.gameObject.transform.position = new Vector3(7.9f, 0.93f, 0.171f);
               GameManager.basket.gameObject.transform.rotation = Quaternion.identity;
                for (int i =gameManager.lemonList.Count - 1; i >= 1; i--)
                {

                   gameManager.lemonList.RemoveAt(i);
                }
                StartCoroutine(RespawnBasketAndLemons2());
            }
        }

        if (other.CompareTag("lemonadeTakeZone"))
        {

            if(gameManager.lemonadeHave)
            {
               gameManager.takeLemonadeCount += gameManager.lemonadeCount;
               gameManager.didGetLemonade = true;

                for (int i = 0; i < gameManager.takeLemonadeCount; i++)
                {
                   gameManager.takeLemonadeArray[i].SetActive(true);
                }
                for (int i = 0; i < gameManager.lemonadeCount; i++)
                {
                   gameManager.lemonade1Array[i].SetActive(false);
                }


               gameManager.lemonadeCount = 0;
                

            }
           
        }

        if (other.CompareTag("lemonadeTakeZone2"))
        {

            if (gameManager.lemonadeHave)
            {
               gameManager.takeLemonadeCount += gameManager.lemonadeCount2;
               gameManager.didGetLemonade = true;

                for (int i = 0; i < gameManager.takeLemonadeCount; i++)
                {
                   gameManager.takeLemonadeArray[i].SetActive(true);
                }
                for (int i = 0; i < gameManager.lemonadeCount2; i++)
                
                   gameManager.lemonade2Array[i].SetActive(false);
                }

               gameManager.lemonadeCount2 = 0;

            }

        

        if (other.CompareTag("SaleZone"))
        {
            if(gameManager.didGetLemonade)
            {
               gameManager.saleZoneLemonadeCount += gameManager.takeLemonadeCount;
               gameManager.didGetLemonade = false;

                for (int i = 0; i < gameManager.saleZoneLemonadeCount; i++)
                {
                   gameManager.saleZoneLemonadeArray[i].SetActive(true);
                }

                for (int i = 0; i < gameManager.takeLemonadeCount; i++)
                {
                   gameManager.takeLemonadeArray[i].SetActive(false);
                }

               gameManager.takeLemonadeCount = 0;
   
            }
        }     

                


        if (other.CompareTag("MoneyTakeZone"))
        {
            StartCoroutine(TakeMoneyDelay());

           gameManager.activeMoneys = GameObject.FindGameObjectsWithTag("money");
            for (int i = 0; i < gameManager.activeMoneys.Length; i++)
            {
                gameManager.money[i].SetActive(false);
                gameManager.moneyCount += 200;
            }

           gameManager.moneyText.text =gameManager.moneyCount.ToString();


        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("newTreeZone"))
        {
            if(gameManager.moneyCount>=200)
            {
               gameManager.newTreeTextCount -= 4f;
                
               gameManager.newTreeText.text = ((int)gameManager.newTreeTextCount).ToString();
            }
    
            
        }

        if (other.CompareTag("newTableZone"))
        {
            if(gameManager.moneyCount>=200)
            {
               gameManager.newTableTextCount -= 4f;
                
               gameManager.newTableText.text = ((int)gameManager.newTableTextCount).ToString();
            }
            
        }
    }

  


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Lemon1"))
        {
           
           


            

        }

        if (collision.gameObject.CompareTag("Lemon2"))
        {

          

            collision.transform.SetParent(gameManager.basketTransform);
            collision.gameObject.transform.localPosition = new Vector3(0,gameManager.lemonList[gameManager.lemonList.Count - 1].transform.localPosition.y + 0.71f, 0);
            gameManager.lemonList.Add(collision.gameObject);

        }
    }



    IEnumerator RespawnBasketAndLemons()
    {
        GameManager.basketActive = false;
        Vector3[] lemons1Pos = new[] { new Vector3(-0.878f, 2.724385f, -0.8719175f), new Vector3(0.03799987f, 2.690385f, -0.9569175f) };
        Vector3[] lemons2Pos = new[] { new Vector3(-0.878f, 2.724385f, -0.8719175f), new Vector3(0.03799987f, 2.690385f, -0.9569175f), new Vector3(-0.878f, 3.412f, -0.516f), new Vector3(-0.169f, 3.366f, -0.888f) };
        yield return new WaitForSeconds(3);
        GameManager.basket.SetActive(false);
        GameManager.basket.transform.SetParent(transform);
        GameManager. basket.gameObject.transform.localPosition = new Vector3(0, 0.276f, 0.4f);


        for (int i = 0; i < gameManager.lemonadeCount; i++)
        {
           gameManager.lemonade1Array[i].SetActive(true);
        }

        if (gameManager.tree1HaveLemons == false)
        {
            foreach (var item in GameManager.lemons1)
            {

                item.gameObject.GetComponent<Rigidbody>().useGravity = false;
                item.gameObject.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;


            }


            for (int i = 0; i < 2; i++)
            {

                GameManager.lemons1[i].gameObject.transform.SetParent(gameManager.tree1Transform);
                GameManager.lemons1[i].gameObject.transform.localPosition = lemons1Pos[i];


            }

            if (gameManager.tree2HaveLemons == false)
            {
                foreach (var item in GameManager.lemons2)
                {

                    item.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    item.gameObject.GetComponent<SphereCollider>().enabled = true;
                    item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                    item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                    item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;


                }

                for (int i = 0; i < 4; i++)
                {

                    GameManager.lemons2[i].gameObject.transform.SetParent(gameManager.tree2Transform);
                    GameManager.lemons2[i].gameObject.transform.localPosition = lemons2Pos[i];

                }





            }
        }


    }

    IEnumerator RespawnBasketAndLemons2()
    {
       GameManager.basketActive = false;

        Vector3[] lemons1Pos = new[] { new Vector3(-0.878f, 2.724385f, -0.8719175f), new Vector3(0.03799987f, 2.690385f, -0.9569175f) };
        Vector3[] lemons2Pos = new[] { new Vector3(-0.878f, 2.724385f, -0.8719175f), new Vector3(0.03799987f, 2.690385f, -0.9569175f),new Vector3(-0.878f, 3.412f, -0.516f),new Vector3(-0.169f, 3.366f, -0.888f) };

        yield return new WaitForSeconds(3);
       GameManager.basket.SetActive(false);
       GameManager.basket.transform.SetParent(transform);
       GameManager.basket.gameObject.transform.localPosition = new Vector3(0, 0.276f, 0.4f);

        for (int i = 0; i < gameManager.lemonadeCount2; i++)
        {
           gameManager.lemonade2Array[i].SetActive(true);
        }

        if(gameManager.tree1HaveLemons==false)
        {
            foreach (var item in GameManager.lemons1)
            {

                item.gameObject.GetComponent<Rigidbody>().useGravity = false;
                item.gameObject.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;


            }


            for (int i = 0; i < 2; i++)
            {
               
                    GameManager.lemons1[i].gameObject.transform.SetParent(gameManager.tree1Transform);
                    GameManager.lemons1[i].gameObject.transform.localPosition = lemons1Pos[i];

                
            }
        }

        if (gameManager.tree2HaveLemons == false)
        {
            foreach (var item in GameManager.lemons2)
            {

                item.gameObject.GetComponent<Rigidbody>().useGravity = false;
                item.gameObject.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;


            }

            for (int i = 0; i < 4; i++)
            {
                
                    GameManager.lemons2[i].gameObject.transform.SetParent(gameManager.tree2Transform);
                    GameManager.lemons2[i].gameObject.transform.localPosition = lemons2Pos[i];

            }

        


            
        }

        

    }


    IEnumerator TakeMoneyDelay()
    {
       gameManager.takeMoney = true;
        yield return null;
        gameManager.takeMoney = false;
    }
    
   

   
}
