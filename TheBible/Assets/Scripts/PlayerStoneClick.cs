using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStoneClick : MonoBehaviour
{
    public Animator MainCharAnim;
    bool isHurt;
    private void Start()
    {
        MainCharAnim.SetBool("hurt", false);
        isHurt = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone2"))
        {
            MainCharAnim.SetBool("hurt", true);
            isHurt = true;
            Invoke("setHurtState", 0.7f);
        }
    }

    private void setHurtState()
    {
        isHurt = false;
        MainCharAnim.SetBool("hurt", false);
    }
}
