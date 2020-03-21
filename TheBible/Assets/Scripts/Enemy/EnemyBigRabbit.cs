using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigRabbit : EnemyRabbit, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    private Rigidbody2D prefabRigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        base.hp = 4;
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
            Debug.Log("EnemyFox is Angry");
            speed = 1;
        }
        else
        {
            speed = 0.5f;
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
            WaveGameManager.instance.EnemyWavePool[1].Despawn(gameObject);
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
        WaveGameManager.instance.EnemyWavePool[1].Despawn(prefab);
    }
}
