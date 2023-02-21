using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public PlayerMovement playerMovement;
    
    public PlayerAnimation playerAnimation;
    
    public PlayerInput playerInput;


    
    


    private void Start()
    {
        
    }

    private void Update()
    {
        playerMovement.Move(playerInput.joystick, playerAnimation.anim);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractableWithPlayer>() != null)
        {
            other.gameObject.GetComponent<IInteractableWithPlayer>().InteractWithPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IInteractableWithPlayer>() != null)
        {
            collision.gameObject.GetComponent<IInteractableWithPlayer>().InteractWithPlayer();
        }
    }

   


}
