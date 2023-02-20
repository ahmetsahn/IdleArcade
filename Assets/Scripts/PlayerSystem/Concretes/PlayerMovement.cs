using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 2;
    [SerializeField]
    private Rigidbody rb;

    public void DefaultMove(FloatingJoystick joystick, Animator anim)
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("HaveBasketIdle", false);
            anim.SetBool("HaveBasketWalking", false);    
            anim.SetBool("DefaultIdle", false); 
            anim.SetBool("DefaultWalking", true);
        }

        else
        {
            anim.SetBool("HaveBasketWalking", false);
            anim.SetBool("HaveBasketIdle", false);
            anim.SetBool("DefaultWalking", false);
            anim.SetBool("DefaultIdle", true);
        }
    }

    public void HaveBasketMove(FloatingJoystick joystick, Animator anim)
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("DefaultWalking", false);
            anim.SetBool("DefaultIdle", false);
            anim.SetBool("HaveBasketIdle", false);
            anim.SetBool("HaveBasketWalking", true);
        }

        else
        {
            anim.SetBool("DefaultWalking", false);
            anim.SetBool("DefaultIdle", false);
            anim.SetBool("HaveBasketWalking", false);
            anim.SetBool("HaveBasketIdle", true);
        }
    }
}
