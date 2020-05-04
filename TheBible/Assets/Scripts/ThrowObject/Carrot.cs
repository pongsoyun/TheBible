using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : ThrowObject, IDespawnable
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
            collision.gameObject.GetComponent<EnemyRabbit>().hp--;
            CancelInvoke();
            Debug.Log($"Carrot Eat! hp : {collision.gameObject.GetComponent<EnemyRabbit>().hp}");
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
            OnDespawn(gameObject);
        }
        catch(ArgumentOutOfRangeException arguException)
        {
            Debug.Log($"예외 발생!");
            Destroy(gameObject);
        }
    }
}
