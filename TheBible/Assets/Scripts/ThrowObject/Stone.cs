using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : ThrowObject, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    protected override void OnEnable()
    {
        base.OnEnable();
        Invoke("Despawn", 3f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ThrowObject"))
        {
            CancelInvoke();
            Despawn();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Stone Eat!");
            collision.gameObject.GetComponent<EnemyRabbit>().isAngry = true;
            CancelInvoke();
            Despawn();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Destroy");
            CancelInvoke();
            Despawn();
        }
       
    }

    private void Despawn()
    {
        try
        {
            GamePlayerMove.instance.throwObjectPool[(int)ThrowType.Stone].Despawn(gameObject);
        }
        catch (ArgumentOutOfRangeException arguException)
        {
            Debug.Log($"예외 발생!");
            Destroy(gameObject);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //}
}
