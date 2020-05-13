﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderEventTrigger : MonoBehaviour
{
    [SerializeField]
    CharacterMove Player;

    public ParticleSystem Aura;
    public ParticleSystem ActionParticle;

    public Animator MiniRbAnim;
    public Animator PlayerAnim;

    bool isPet = false; // position을 위함. Player따라다닐 RB
    bool isFirstEvent = true;
    float cureAmount = 0f;
    public AudioSource cureAudio;
    void Start()
    {
        Aura.Stop();
        ActionParticle.Stop();
    }

    void Update()
    {
        // miniRB position
        if (isPet)
        {
            if (MiniRbAnim.GetCurrentAnimatorStateInfo(0).IsName("Rabbit_Sick"))
            {
                Player.isPlayed = true;
            }
            else if (MiniRbAnim.GetCurrentAnimatorStateInfo(0).IsName("Rabbit_Happy"))
            {
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x - 1.15f, 0.1f),
                                            Mathf.Lerp(transform.position.y, Player.transform.position.y + 0.2f, 0.1f),
                                            transform.position.z);
            }
            else
            {
                Player.isPlayed = false;
                transform.position = new Vector3(Player.transform.position.x - 1.15f, Player.transform.position.y + 0.2f, transform.position.z);
            }
        }

        // Animation - magic
        if (!Input.GetKey(KeyCode.E))
        {
            PlayerAnim.SetBool("magic", false);
        }
    }

    void DebugEvent()
    {
        Debug.Log("EventTriggerON");
        if (Input.GetKey(KeyCode.E))
        {
            cureAmount += 0.01f;
            Aura.Emit(1);
            ActionParticle.Emit(1);
            PlayerAnim.SetBool("magic", true);
        }

        if (cureAmount >= 1.0f)
        {
            Debug.Log("isPet True!");
            MiniRbAnim.SetBool("Cure", true); // animation 변경(Cured RB으로)
            cureAudio.Play();
            Invoke("SetPositionPet", 2f);
            cureAmount = 0;
        }
    }

    void SetPositionPet()
    {
        isPet = true; // 따라다니기
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EventEnter");
        Player.eventClear();
        Player.ActivateEvent += DebugEvent;
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    // Debug.Log("EventExit");
    //    //Player.ActivateEvent -= DebugEvent;
    //    //FilledImage.fillAmount = 1f;
    //}
}
