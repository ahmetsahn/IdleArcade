using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class UnlockTriggerZone : MonoBehaviour,IInteractableWithPlayer
{
    [SerializeField]
    private int price;

    [SerializeField]
    private TMP_Text priceText;

    [SerializeField]
    private UIController uiController;

    [SerializeField]
    private GameObject unlockObject;

    public void InteractWithPlayer(Player player)
    {
        if (uiController.currentMoney >= price)
        {
            DOTween.To(() =>uiController.currentMoney, x => uiController.currentMoney = x, uiController.currentMoney-price, 2f);
            DOTween.To(() => price, x => price = x, 0, 2f).onComplete += () =>
            SetActive(); 
            
        }
    }

    private void Update()
    {
        priceText.text = "$" +price.ToString();
        uiController.moneyText.text = uiController.currentMoney.ToString() + " $";
    }

    private void SetActive()
    {
        gameObject.SetActive(false);
        unlockObject.SetActive(true);  
    }
    
}
