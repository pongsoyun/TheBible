using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmallRabbit : EnemyRabbit, IDespawnable
{
    public event Action<GameObject> OnDespawn;
    private Rigidbody2D prefabRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        prefabRigidBody2D = GetComponent<Rigidbody2D>();
        OnDespawn += KillDespawn;
        WaveGameManager.instance.ActiveEnemyCount++;
        Debug.Log($"{nameof(gameObject)} Count++! :{ WaveGameManager.instance.ActiveEnemyCount} ");

    }

    // Update is called once per frame
    void Update()
    {
        if (isAngry)
        {
            Debug.Log($"{nameof(gameObject)} is Angry");
            speed = 2;
        }
        else
        {
            speed = 1;
        }
        prefabRigidBody2D.velocity = transform.right * speed * -1;// Go to Left
        if (hp <= 0)
            OnDespawn(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TestEndZone"))
        {
            WaveGameManager.instance.killCount++;
            WaveGameManager.instance.ActiveEnemyCount--;
            WaveGameManager.instance.EnemyWavePool[0].Despawn(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            OnDespawn(gameObject);
            GamePlayerMove.instance.playerHP--;
            Debug.Log("Player Hit!");
        }
    }

    private void KillDespawn(GameObject prefab)
    {
        Debug.Log("Kill Called");
        WaveGameManager.instance.EnemyWavePool[0].Despawn(prefab);
    }
}
