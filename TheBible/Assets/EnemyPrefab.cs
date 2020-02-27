using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : MonoBehaviour, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    // Start is called before the first frame update
    void Start()
    {
        OnDespawn += testDespawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            WaveGameManager.instance.EnemyPool.Despawn(gameObject);
        }
    }

    private void testDespawn(GameObject prefab)
    {

    }
}
