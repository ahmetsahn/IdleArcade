using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> lemonList = new List<GameObject>();
    public Text moneyText;
    [SerializeField] GameObject newTree;
    [SerializeField] GameObject newTable;
    [SerializeField] GameObject newTreeZone;
    [SerializeField] GameObject newTableZone;
    
    public static GameObject[] lemons1;
    public static GameObject[] lemons2;
    public GameObject[] lemonade1Array;
    public GameObject[] lemonade2Array;
    public GameObject[] takeLemonadeArray;
    public GameObject[] saleZoneLemonadeArray;
    public GameObject[] activeMoneys;
    public GameObject[] money;
    public Transform basketTransform;
   
    public Transform tree1Transform;
    public Transform tree2Transform;
    

    public TMP_Text newTreeText;
    public TMP_Text newTableText;
    public float newTreeTextCount;
    public float newTableTextCount;
    public float moneyCount;
    public GameObject treeText;
    public GameObject tableText;
    public static GameObject basket;
    public static bool basketActive = false;
    public bool tree1HaveLemons = true;
    public bool tree2HaveLemons = true;
    public static int lemonCount;
    public int lemonadeCount;
    public int lemonadeCount2;
    public int takeLemonadeCount;
    public int saleZoneLemonadeCount;
    public bool lemonadeHave = false;
    public bool didGetLemonade = false;
    public bool takeMoney;
    public int moneyStackNumber;


    private void Start()
    {
        saleZoneLemonadeCount = 0;
        newTreeTextCount = 200;
        newTableTextCount = 200;
        lemonCount = 0;
        takeLemonadeCount = 0;
        lemonadeCount = 0;
        takeMoney = false;
    }

    private void Update()
    {
        if (newTreeTextCount < 0)
        {
            moneyCount -= 200;
            newTreeTextCount = 0;
            moneyText.text = moneyCount.ToString();


            treeText.SetActive(false);
            newTree.SetActive(true);
            newTreeZone.SetActive(false);
        }

        if (newTableTextCount < 0)
        {
            moneyCount -= 200;
            moneyText.text = moneyCount.ToString();
            newTableTextCount = 0;

            tableText.SetActive(false);
            newTable.SetActive(true);
            newTableZone.SetActive(false);
        }
    }
}
