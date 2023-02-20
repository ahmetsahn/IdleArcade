using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lemons;

   


    private GameObject GetPooledObjectForActive()
    {

        for (int i = 0; i < lemons.Length; i++)
        {
            if (!lemons[i].activeSelf)
            {
                return lemons[i];
            }
        }

        return null;

    }

    private void ActiveObject()
    {
       
            GameObject obj = GetPooledObjectForActive();
            if (obj != null)
            {
                obj.SetActive(true);
            }
       
    }

    private GameObject GetPooledObjectForDeactive()
    {

        for (int i = lemons.Length - 1; i >= 0; i--)
        {

            if (lemons[i].activeSelf)
            {
                return lemons[i];
            }
        }

        return null;

    }

    private void DeactiveObject()
    {
      
            GameObject obj = GetPooledObjectForDeactive();
            if (obj != null)
            {
                obj.SetActive(false);
            }
        

    }

  

}
