using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickRabbit : MonoBehaviour
{
    public Animator CureKingAnim;
    public bool isAbleCure;
    // Start is called before the first frame update
    void Start()
    {
        CureKingAnim.SetBool("Cure", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAbleCure = true;
        }
        // 이제 Player의 게이지 찼을 경우 SetBool("Cure", false);
    }
}
