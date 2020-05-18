using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class SceneSeparator : MonoBehaviour
{
    [SerializeField]
    PlayableDirector beforeDirector;
    [SerializeField]
    PlayableDirector afterDirector;
    [SerializeField]
    CharacterMove Player;

    public GameObject MGEndingRabbits;
    public GameObject EndingPlay;
    //public bool isBeforeCpt = true;

    private bool isPlayOnceBefore = false;
    private bool isPlayOnceAfter = false;

    void Start()
    {
        MGEndingRabbits.SetActive(false);
        beforeDirector.played += PlayerStopOn;
        beforeDirector.stopped += PlayerStopOff;
        afterDirector.played += PlayerStopOn;
        afterDirector.stopped += PlayerStopOff;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayOnceBefore && GameManager.instance.isBeforeCpt && collision.CompareTag("Player"))
        {
            isPlayOnceBefore = true;
            beforeDirector.Play();
        }
        else if (!isPlayOnceAfter && isPlayOnceBefore && !GameManager.instance.isBeforeCpt && collision.CompareTag("Player"))
        {
            MGEndingRabbits.SetActive(true);
            isPlayOnceAfter = true;
            afterDirector.Play();
            EndingPlay.SetActive(true);
        }
    }

    private void PlayerStopOn(PlayableDirector playable)
    {
        Player.isPlayed = true;
    }

    private void PlayerStopOff(PlayableDirector playable)
    {
        Player.isPlayed = false;
    }
}
