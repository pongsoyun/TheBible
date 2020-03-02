using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }

        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //gameObject.GetComponent<클래스명>.체력--;
            //Despawn;
        }
    }
}
