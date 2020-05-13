﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SickRabbit : MonoBehaviour
{
    [SerializeField]
    CharacterMove Player;

    public ParticleSystem Aura;
    public ParticleSystem ActionParticle;
    public Animator CureKingAnim;
    public Animator PlayerAnim;
    public bool isAbleCure;
    public bool isFirstEvent = true;  // 일단.. 긴급 처방.. 

    public Animator MiniRbAnim;
    public bool isMiniRbAnimPlay = false;

    // public GameObject BubbleKingCure;
    public GameObject BubbleTogether;
    private AudioSource audio;
    public AudioClip CureSound;
    Animator animator;
    float fillAmount;

    void Start()
    {
        Aura.Stop();
        ActionParticle.Stop();

        // BubbleKingCure.SetActive(false);
        BubbleTogether.SetActive(false);


        // sound
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = CureSound;
        audio.loop = false;
        audio.volume = 0.8f;
    }

    void Update()
    {
        DebugEvent();
        if (!Input.GetKey(KeyCode.E))
        {
            PlayerAnim.SetBool("magic", false);
        }

        if (BubbleTogether.activeInHierarchy)
        {
            animator = BubbleTogether.GetComponent<Animator>();

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Bubble_Together"))
            {
                BubbleTogether.GetComponentInParent<CharacterMove>().isPlayed = true;
                Debug.Log("Bubble_Together is Playing!");
            }
            else
            {
                BubbleTogether.GetComponentInParent<CharacterMove>().isPlayed = false;
                Debug.Log("Bubble_Together Stop!");
            }
        }
    }

    void DebugEvent()
    {
        Debug.Log("EventTriggerON");
        if (Input.GetKey(KeyCode.E))
        {
            fillAmount += 0.01f;
            Aura.Emit(1);
            ActionParticle.Emit(1);
            PlayerAnim.SetBool("magic", true);
            // 애기 놀람 
            if (!isMiniRbAnimPlay)
            {
                MiniRbAnim.SetBool("shock", true);
                isMiniRbAnimPlay = true;
            }
        }

        if (fillAmount >= 1.0f)
        {
            CureKingAnim.SetBool("cure", true);
            audio.Play();
            Invoke("PlayBubbleTogether", 1f);
            fillAmount = 0;
        }
    }

    private void PlayBubbleTogether()
    {
        BubbleTogether.SetActive(true);
    }
}
