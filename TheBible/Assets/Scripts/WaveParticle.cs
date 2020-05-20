using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour, IDespawnable
{
    //ParticleSystem Aura;

    public event Action<GameObject> OnDespawn;

    void OnEnable()
    {
        Invoke("DespawnParticle", 0.5f);
    }

    void DespawnParticle()
    {
        //WaveGameManager.instance.ParticlePool.Despawn(gameObject);
        OnDespawn(gameObject);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    // Aura.Play();
    //    // Aura.Pause();
    //    // Aura.Emit(1); // 1개의 입자만.
    //    // Aura.Stop();
    //}
}
