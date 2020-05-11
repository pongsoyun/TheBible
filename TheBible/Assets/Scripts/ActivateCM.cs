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

    public bool isFlimBar = false;

    GameObject Player = null;
    bool isPlayOnce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayOnce && collision.CompareTag(tagName))
        {
            isPlayOnce = true;
            Player = collision.gameObject;
            if (isFlimBar)
            {
                director.played += GameManager.instance.FilmBarOn;
                director.stopped += GameManager.instance.FilmBarOff;
            }
            director.played += PlayerStopOn;
            director.stopped += PlayerStopOff;
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
