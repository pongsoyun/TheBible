using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMouse : ThrowObject, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    private float powerWeight;

    protected override void OnEnable()
    {
        transform.SetParent(null);
        PowerSet();
        gameObject.GetComponent<Rigidbody2D>().velocity = MouseGameManager.instance.throwPower;
    }

    protected override void PowerSet()
    {
        powerWeight = 18f;
        MouseGameManager.instance.throwPower *= powerWeight;
    }

    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} was Clicked");
        MouseGameManager.instance.StonePool.Despawn(gameObject);
        MouseGameManager.instance.killCount++;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Despawn!");
            MouseGameManager.instance.StonePool.Despawn(gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            MouseGameManager.instance.StonePool.Despawn(gameObject);
        }
    }
}
