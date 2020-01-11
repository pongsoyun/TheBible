using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CineMachineEvent : MonoBehaviour
{
    public PlayableDirector playableDirector;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} : Tag is {collision.gameObject.tag}");
        if (collision.gameObject.CompareTag("Trigger"))
        {
            playableDirector.Play();
        }
    }
}
