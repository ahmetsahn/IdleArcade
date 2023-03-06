using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int currentMoney { get; set; } = 0;
    public int moneyValue { get; set; } = 200;

    public void UpdateMoneyText()
    {
        moneyText.text = currentMoney.ToString() + " $";
    }

    public void IncreamentMoney(int moneyCount)
    {
        currentMoney += moneyValue * moneyCount;
    }
}
