using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UnlockTriggerZone : MonoBehaviour,IInteractableWithPlayer
{
    [SerializeField]
    private int price;
    public TMP_Text priceText;

    public void InteractWithPlayer()
    {
        DOTween.To(() => price, x => price = x, 0, 2f);
    }

    private void Update()
    {
        priceText.text = "$" +price.ToString();
    }
    
}
