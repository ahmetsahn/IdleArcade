using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 2;
    [SerializeField]
    private Rigidbody rb;

    public void Move(FloatingJoystick joystick, Animator anim)
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            anim.SetBool("walk", true);
        }

        else
        {
            anim.SetBool("walk", false);
        }
    }
}
