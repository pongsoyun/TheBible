using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : ThrowObject, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    //void Update()
    //{

    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyRabbit>().hp--;
            GamePlayerMove.instance.throwObjectPool[(int)ThrowType.Carrot].Despawn(gameObject);
            Debug.Log($"Carrot Eat! hp : {collision.gameObject.GetComponent<EnemyRabbit>().hp}");
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Destroy");
            GamePlayerMove.instance.throwObjectPool[(int)ThrowType.Carrot].Despawn(gameObject);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {

    //    }
    //    else if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        collision.gameObject.GetComponent<EnemyRabbit>().hp--;
    //        GamePlayerMove.instance.throwObjectPool[(int)ThrowType.Carrot].Despawn(gameObject);
    //        Debug.Log($"Carrot Eat! hp : {collision.gameObject.GetComponent<EnemyRabbit>().hp}");
    //    }
    //    else if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        Debug.Log("Ground Destroy");
    //        GamePlayerMove.instance.throwObjectPool[(int)ThrowType.Carrot].Despawn(gameObject);
    //    }
    //}
}
