using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private GameObject Stone;

    public MemoryPool StonePool;
    public bool isCptHomeEnd = false;
    public Vector2 throwPower;
    private bool isInit = false;


    void Update()
    {
        if (isCptHomeEnd && !isInit)
        {
            isInit = true;
            StonePool = new MemoryPool(Stone, 5, 10);
        }    
    }
}
