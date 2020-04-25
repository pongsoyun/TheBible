using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateCM : MonoBehaviour
{
    [SerializeField]
    PlayableDirector director;
    [SerializeField]
    string tagName;

    bool isPlayOnce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isPlayOnce && collision.CompareTag(tagName))
        {
            isPlayOnce = true;
            director.Play();
        }
    }
}
