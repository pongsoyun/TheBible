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
        OnDespawn += KillDespawn;
        WaveGameManager.instance.ActiveEnemyCount++;
        Debug.Log($"Active Enemy Count++! :{ WaveGameManager.instance.ActiveEnemyCount} ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TestEndZone"))
        {
            WaveGameManager.instance.killCount++;
            WaveGameManager.instance.ActiveEnemyCount--;
            WaveGameManager.instance.EnemyWavePool.Despawn(gameObject);
        }
    }

    private void KillDespawn(GameObject prefab)
    {

    }
}
