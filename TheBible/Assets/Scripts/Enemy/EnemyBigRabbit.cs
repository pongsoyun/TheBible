using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigRabbit : EnemyRabbit, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    private Rigidbody2D prefabRigidBody2D;

    public Animator BigRbAnim;

    // Start is called before the first frame update
    void Start()
    {
        hp = 4;
        prefabRigidBody2D = GetComponent<Rigidbody2D>();
        OnDespawn += Despawn;
        WaveGameManager.instance.ActiveEnemyCount++;
        Debug.Log($"{nameof(gameObject)} Count++! :{ WaveGameManager.instance.ActiveEnemyCount} ");
    }

    void OnEnable()
    {
        hp = 4;
        isAngry = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAngry)
        {
            BigRbAnim.SetBool("Angry", true);
            Debug.Log("EnemyFox is Angry");
            speed = 3;
        }
        else
        {
            speed = 1.5f;
            BigRbAnim.SetBool("Angry", false);
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
            WaveGameManager.instance.EnemyWavePool[(int)RabbitType.BigRabbit].Despawn(gameObject);
            GamePlayerMove.instance.playerHP--;
            Debug.Log("Player Hit!");
        }
        if (collision.gameObject.CompareTag("EndZone"))
        {
            WaveGameManager.instance.EnemyWavePool[(int)RabbitType.BigRabbit].Despawn(gameObject);
        }
    }

    private void Despawn(GameObject prefab)
    {
        WaveGameManager.instance.ParticlePool.Respawn(prefab.transform.position, prefab.transform.rotation);
        WaveGameManager.instance.EnemyWavePool[(int)RabbitType.BigRabbit].Despawn(prefab);
    }
}
