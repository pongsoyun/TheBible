using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFox : MonoBehaviour, IDespawnable
{
    public int hp = 2;
    public bool isAngry = false;
    private int speed = 1;

    public event Action<GameObject> OnDespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAngry)
        {
            //여우가 짱짱 쎄지는 거시와요 하와와...
        }
        else
        {
            //화나지 않는 거시와요...
        }
    }
}
