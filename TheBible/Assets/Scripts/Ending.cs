using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private GameObject Stone;

    public MemoryPool StonePool;
    public bool isCptHomeEnd = false;
    private bool isInit = false;

    void Update()
    {
        //Debug.Log($"isInit : {isInit}");
        if (isCptHomeEnd && !isInit)
        {
            isInit = true;
            StonePool = new MemoryPool(Stone, 5, 10);
            StartCoroutine(StoneSpawn());
        }    
    }

    IEnumerator StoneSpawn()
    {
        while (true)
        {
            StonePool.Respawn(transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
    }
}
