using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateCM : MonoBehaviour
{
    [SerializeField]
    PlayableDirector director;
    [SerializeField]
    string tagName = "Player";
    [SerializeField]
    GameObject Player;
    bool isPlayOnce = false;

    private void Start()
    {
        director.played += PlayerStopOn;
        director.stopped += PlayerStopOff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayOnce && collision.CompareTag(tagName))
        {
            isPlayOnce = true;
            director.Play();
        }
    }

    private void PlayerStopOn(PlayableDirector playable)
    {
        Player.GetComponent<CharacterMove>().isPlayed = true;
    }

    private void PlayerStopOff(PlayableDirector playable)
    {
        Player.GetComponent<CharacterMove>().isPlayed = false;
    }
}
