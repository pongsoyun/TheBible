using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTrace : MonoBehaviour
{
    public float weight;
    float deltaFloat;
    int degree;
    // Update is called once per frame
    void Update()
    {
        deltaFloat += Mathf.Sin(degree++*weight);
        transform.localPosition = new Vector2(0, 2.75f + Mathf.Sin(deltaFloat)*0.1f);
        if (degree >= 360)
            degree = 0;
        Debug.Log($"delta : {Mathf.Sin(degree)}, Total : {deltaFloat}");
    }
}
