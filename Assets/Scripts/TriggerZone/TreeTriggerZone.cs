using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTriggerZone : MonoBehaviour,IInteractableWithPlayer
{
    [SerializeField]
    protected GameObject[] lemons;

    private void OnEnable() => GameEvents.OnTriggerTree += SetGravityActive;


    public void InteractWithPlayer(Player player)
    {
        SetGravityActive();
    }

    private void SetGravityActive()
    {
        for (int i = 0; i < lemons.Length; i++)
        {
            lemons[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
