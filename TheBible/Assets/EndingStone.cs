using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingStone : ThrowObject, IDespawnable
{
    public event Action<GameObject> OnDespawn;
    public Ending endingObj;

    private float powerWeight;

    protected override void OnEnable()
    {
        transform.SetParent(null);
        PowerSet();
        gameObject.GetComponent<Rigidbody2D>().velocity = endingObj.throwPower;
    }

    protected override void PowerSet()
    {
        powerWeight = UnityEngine.Random.Range(5f,8f);
        endingObj.throwPower *= powerWeight;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        try
        {
            endingObj.StonePool.Despawn(gameObject);
        }
        catch(ArgumentOutOfRangeException e)
        {
            Debug.Log($"예외 발생!");
            Destroy(gameObject);
        }
    }
}
