using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffPetCollider : MonoBehaviour
{
    // Player가 여기 부딛히면 끄기
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 여기서 sickRabbit OFF(우로 빠지기?)
        }
    }
}
