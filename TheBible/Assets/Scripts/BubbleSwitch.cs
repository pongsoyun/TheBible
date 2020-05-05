using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSwitch : MonoBehaviour
{
    [SerializeField]
    GameObject Bubble;
    // [SerializeField]
    // string animParamString;
    bool isBubbleOnce;
    // Update is called once per frame

    void Start()
    {
        isBubbleOnce = false;
        Bubble.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isBubbleOnce && collision.CompareTag("Player"))
        {
            Bubble.SetActive(true);
            isBubbleOnce = true;
        }
    }
}
