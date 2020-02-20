﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderEventTrigger : MonoBehaviour
{
    CharacterMove Player;
    [SerializeField]
    private Image FilledImage;
    // Start is called before the first frame update
    void Awake()
    {
        Player = FindObjectOfType<CharacterMove>();
    }

    void DebugEvent()
    {
        Debug.Log("EventTriggerON");
        if (Input.GetKey(KeyCode.E))
        {
            FilledImage.fillAmount += 0.01f;
        }
        if (FilledImage.fillAmount >= 1.0f)
        {
            Debug.Log("FilledImage Reset 1.0 to 0!");
            FilledImage.fillAmount = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EventEnter");
        Player.eventClear();
        Player.ActivateEvent += DebugEvent;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       //Debug.Log("EventExit");
       //Player.ActivateEvent -= DebugEvent;
        FilledImage.fillAmount = 1f;
    }
}
