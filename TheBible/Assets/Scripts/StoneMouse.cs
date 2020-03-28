using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMouse : ThrowObject, IDespawnable
{
    public event Action<GameObject> OnDespawn;


    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} was Clicked");
        MouseGameManager.instance.StonePool.Despawn(gameObject);
        MouseGameManager.instance.killCount++;
    }

    protected override void PowerSet()
    {
        base.PowerSet();
    }
}
