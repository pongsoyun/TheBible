using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParticle : MonoBehaviour
{
    ParticleSystem Aura;
    void OnEnable()
    {
        Invoke("DespawnParticle", 0.5f);
    }

    void DespawnParticle()
    {
        WaveGameManager.instance.ParticlePool.Despawn(gameObject);
    }
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    // Aura.Play();
    //    // Aura.Pause();
    //    // Aura.Emit(1); // 1개의 입자만.
    //    // Aura.Stop();
    //}
}
