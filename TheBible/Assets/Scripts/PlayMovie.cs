using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovie : MonoBehaviour
{
    public Animator MovieAnim;
    // Start is called before the first frame update
    void Start()
    {
        // Animator = GetComponent<Animator>();
        MovieAnim.SetBool("play", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("play movie~");
            MovieAnim.SetBool("play", true);
        }
    }
}
