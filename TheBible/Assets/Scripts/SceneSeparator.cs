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

    public GameObject ThrowRabbits;
    public bool isBeforeCpt = true;
    private bool isPlayOnceBefore = false;
    private bool isPlayOnceAfter = false;

    public Animator MainCharAnim;

    void Start()
    {
        MGEndingRabbits.SetActive(false);
        ThrowRabbits.SetActive(false);
        MainCharAnim.SetInteger("hurt", 0);
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
            Invoke("EndingAnimPlay", 10f);
        }
    }

    private void EndingAnimPlay()
    {
        // 돌날아오기 + 토끼들 좌우에서 오기
        ThrowRabbits.SetActive(true);


        // MainChar 멍들어가야함
        Invoke("HurtOne", 5f); // 좌우에서 4초 후 MainChar hurt 1
        MainCharAnim.SetInteger("hurt", 1);
        Invoke("HurtTwo", 4f);

        // 시야줄어들기

    }

    private void HurtOne()
    {
        MainCharAnim.SetInteger("hurt", 2);
    }

    private void HurtTwo()
    {
        MainCharAnim.SetInteger("hurt", 3);
    }
}
