using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStone : ThrowObject, IDespawnable
{
    public event Action<GameObject> OnDespawn;
    public Vector2 throwPower;
    public bool isFlip = false;

    private Vector2 originPower = new Vector2(0.6f, 0.7f);
    private float powerWeight;

    private void Awake()
    {
        if (isFlip)
        {
            originPower = new Vector2(-0.6f, 0.7f);
        }
    }

    protected override void OnEnable()
    {
        throwPower = originPower;
        transform.SetParent(null);
        PowerSet();
        gameObject.GetComponent<Rigidbody2D>().velocity = throwPower;
    }

    protected override void PowerSet()
    {
        powerWeight = UnityEngine.Random.Range(12f, 15f);
        throwPower *= powerWeight;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ThrowObject"))
        {
            try
            {
                OnDespawn(gameObject);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.Log($"예외 발생!");
                Destroy(gameObject);
            }
        } 
    }
}
