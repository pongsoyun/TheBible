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

    public GameObject MGEndingObjs;
    public bool isBeforeCpt = true;
    private bool isPlayOnceBefore = false;
    private bool isPlayOnceAfter = false;

    void Start()
    {
        MGEndingObjs.SetActive(false);
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
            MGEndingObjs.SetActive(true);
            isPlayOnceAfter = true;
            afterDirector.Play();
        }
    }
}
