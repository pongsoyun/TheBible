using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    protected Vector2 power = Vector2.zero;
    

    protected virtual void OnEnable()
    {
        transform.SetParent(null);
        PowerSet();
        if (power.Equals(Vector2.zero))
        {
            Debug.LogError("power not set!");
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = power;
    }

    protected virtual void PowerSet()
    {
        //For WaveGame
        power = GamePlayerMove.throwPower * 8f;
    }
}
