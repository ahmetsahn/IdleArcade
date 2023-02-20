using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public PlayerMovement playerMovement;
    
    public PlayerAnimation playerAnimation;
    
    public PlayerInput playerInput;


    private BasePlayer currentState;

    public DefaultState defaultState = new DefaultState();
    public HaveBasketState haveBasketState = new HaveBasketState();
    


    private void Start()
    {
        currentState = defaultState;
    }

    private void Update()
    {
        currentState.Update(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTrigger(this, other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollision(this, collision);
    }

    public void ChangeState(BasePlayer newState)
    {
        currentState = newState;
    }


}
