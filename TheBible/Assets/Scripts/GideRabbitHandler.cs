using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GideRabbitHandler : MonoBehaviour
{
    bool playGuideRabbit;
    // Start is called before the first frame update
    void Start()
    {
        playGuideRabbit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playGuideRabbit)
        {
            Debug.Log("ohTouch!");
            playGuideRabbit = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playGuideRabbit = true;
            Debug.Log("player touch");
        }
    }
}
