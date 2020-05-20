using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1Collider : MonoBehaviour
{
    public Animator BigRBAnim;
    Vector3 target = new Vector3(150f, -22f, 49.7f);
    public bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        BigRBAnim.SetBool("Throw", false);
        isMove = false;
    }

    void Update()
    {
        if (isMove)
            transform.position = Vector3.Lerp(transform.position, target, 0.005f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BigRBAnim.SetBool("Throw", true);
            isMove = true;
        }
    }
}
