using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ReleaseLemonadeZone : MonoBehaviour, IInteractableWithPlayer
{
    [SerializeField]
    private List<GameObject> lemonadeOnTheTable = new List<GameObject>();

    public TakeLemonadeZone takeLemonadeZone = new TakeLemonadeZone();

    [SerializeField]
    private Transform saleTable;
    public void InteractWithPlayer()
    {
        foreach (GameObject gameObject in takeLemonadeZone.lemonade)
        {
            if (gameObject.activeSelf)
            {
                gameObject.transform.SetParent(saleTable);     
                gameObject.transform.localPosition = new Vector3(lemonadeOnTheTable[lemonadeOnTheTable.Count - 1].transform.localPosition.x + 0.2f, 0.9f , -0.5f);
                lemonadeOnTheTable.Add(gameObject);
            }

        }
    }
}
