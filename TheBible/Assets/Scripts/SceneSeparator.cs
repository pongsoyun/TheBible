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

    public GameObject MGEndingRabbits;
    public GameObject EndingPlay;
    public bool isBeforeCpt = true;

    private bool isPlayOnceBefore = false;
    private bool isPlayOnceAfter = false;

    void Start()
    {
        MGEndingRabbits.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPlayOnceBefore && isBeforeCpt && collision.CompareTag("Player"))
        {
            isBeforeCpt = false;
            isPlayOnceBefore = true;
            beforeDirector.Play();
        }
        else if (!isPlayOnceAfter && isPlayOnceBefore && !isBeforeCpt && collision.CompareTag("Player"))
        {
            MGEndingRabbits.SetActive(true);
            isPlayOnceAfter = true;
            afterDirector.Play();
            EndingPlay.SetActive(true);
        }
    }
}
