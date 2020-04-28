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
        OnDespawn += Despawn;
        WaveGameManager.instance.ActiveEnemyCount++;
        //Debug.Log($"{nameof(gameObject)} Count++! :{ WaveGameManager.instance.ActiveEnemyCount} ");
    }
    void OnEnable()
    {
        hp = 2;
        isAngry = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isAngry)
        {
            //Debug.Log($"{nameof(gameObject)} is Angry");
            speed = 4;
        }
        else
        {
            speed = 2;
        }
        prefabRigidBody2D.velocity = transform.right * speed * -1;// Go to Left
        if (hp <= 0)
        {
            WaveGameManager.instance.killCount++;
            OnDespawn(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Kill Called");
            GamePlayerMove.instance.playerHP--;
            Debug.Log("Player Hit!");
            OnDespawn(gameObject);
        }
        if (collision.gameObject.CompareTag("EndZone"))
        {
            WaveGameManager.instance.EnemyWavePool[(int)RabbitType.SmallRabbit].Despawn(gameObject);
        }
    }

    private void Despawn(GameObject prefab)
    {
        WaveGameManager.instance.ParticlePool.Respawn(prefab.transform.position, prefab.transform.rotation);
        WaveGameManager.instance.EnemyWavePool[(int)RabbitType.SmallRabbit].Despawn(prefab);
    }
}
