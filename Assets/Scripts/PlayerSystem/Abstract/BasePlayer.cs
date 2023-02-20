using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayer
{
    public abstract void Update(Player player);

    public abstract void OnTrigger(Player player, Collider other);

    public abstract void OnCollision(Player player, Collision collision);
}
