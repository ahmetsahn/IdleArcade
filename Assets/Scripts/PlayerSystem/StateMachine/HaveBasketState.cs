using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveBasketState : BasePlayer
{

    public override void Update(Player player)
    {
        player.playerMovement.HaveBasketMove(player.playerInput.joystick, player.playerAnimation.anim);
    }
    public override void OnCollision(Player player, Collision collision)
    {
        if (collision.gameObject.GetComponent<IInteractableWithPlayer>() != null)
        {
            collision.gameObject.GetComponent<IInteractableWithPlayer>().InteractWithPlayer();
        }
    }

    public override void OnTrigger(Player player, Collider other)
    {
        if (other.gameObject.GetComponent<IInteractableWithPlayer>() != null)
        {
            other.gameObject.GetComponent<IInteractableWithPlayer>().InteractWithPlayer();
        }
    }

   
}
