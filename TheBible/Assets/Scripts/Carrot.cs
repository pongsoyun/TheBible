using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    private Vector2 power;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
        power = GamePlayerMove.throwPower;
        power *= 5f;
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
            collision.gameObject.GetComponent<EnemyPrefab>().hp--;
            gameObject.SetActive(false);
            Debug.Log($"Carrot Eat! hp : {collision.gameObject.GetComponent<EnemyPrefab>().hp}");
            //Despawn;
        }
    }
}
