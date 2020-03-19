using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    private Vector2 power;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
        power = GamePlayerMove.throwPower;
        power *= 8f;
        gameObject.GetComponent<Rigidbody2D>().velocity = power;
    }

    //void Update()
    //{

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Stone Eat!");
            collision.gameObject.GetComponent<EnemyPrefab>().isAngry = true;

            //OnDespawn();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Destroy");
            GamePlayerMove.instance.throwObjectPool[(int)ThrowType.Stone].Despawn(gameObject);
        }
    }
}
