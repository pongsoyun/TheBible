using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPlay : MonoBehaviour
{
    [SerializeField]
    GameObject EndingObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EndingObj.SetActive(true);
        }
    }
}
