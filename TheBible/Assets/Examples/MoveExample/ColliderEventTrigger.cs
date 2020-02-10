using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEventTrigger : MonoBehaviour
{
    CharacterMove Player;
    // Start is called before the first frame update
    void Awake()
    {
        Player = FindObjectOfType<CharacterMove>();
    }

    void DebugEvent()
    {
        Debug.Log("EventTriggerON");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("EventEnter");
        Player.ActivateEvent += DebugEvent;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("EventExit");
        Player.ActivateEvent -= DebugEvent;
    }
}
