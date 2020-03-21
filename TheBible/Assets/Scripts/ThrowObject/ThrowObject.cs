using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    private Vector2 power;
    
    protected virtual void OnEnable()
    {
        transform.SetParent(null);
        power = GamePlayerMove.throwPower;
        power *= 8f;
        gameObject.GetComponent<Rigidbody2D>().velocity = power;
    }
}
