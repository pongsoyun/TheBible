using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : ThrowObject, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Stone Eat!");
            collision.gameObject.GetComponent<EnemyRabbit>().isAngry = true;

            //OnDespawn();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Destroy");
            GamePlayerMove.instance.throwObjectPool[(int)ThrowType.Stone].Despawn(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
