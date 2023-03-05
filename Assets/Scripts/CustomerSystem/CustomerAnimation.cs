using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator customerAnim;

    public void StopWalk()
    {
        customerAnim.SetBool("Walk", false);
    }

    public void StartWalk()
    {
        customerAnim.SetBool("Walk", true);
    }


}
