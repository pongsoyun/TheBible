using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour, IDespawnable
{
    public event Action<GameObject> OnDespawn;

    event Action<GameObject> IDespawnable.OnDespawn
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

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
            //gameObject.GetComponent<클래스명>.분노 = true;
            //Despawn;
        }
    }
}
