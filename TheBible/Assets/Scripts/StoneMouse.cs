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
        powerWeight = 11f;
        MouseGameManager.instance.throwPower *= powerWeight;
    }

    private void OnMouseDown()
    {
        Debug.Log($"{gameObject.name} was Clicked");
        Despawn();
        MouseGameManager.instance.killCount++;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MouseGameManager.instance.playerHp--;
            Debug.Log($"Player Hit! Hp : {MouseGameManager.instance.playerHp}");
        }
        Despawn();
    }

    private void Despawn()
    {
        MouseGameManager.instance.ParticlePool.Respawn(transform.position, transform.rotation);
        try
        {
            OnDespawn(gameObject);
        }
        catch(Exception e)
        {
            Debug.Log("예외 발생!");
            Destroy(gameObject);
        }
    }
}
