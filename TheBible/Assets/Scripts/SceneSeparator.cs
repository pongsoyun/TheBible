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
            // 6초 후 큰래빗 bubble 활성화
            Invoke("EndingAnimPlay", 9f); // CM_EndingSmallTalking 다 끝낸 초 후
        }
    }

    private void EndingAnimPlay()
    {
        // 돌날아오기 + 토끼들 좌우에서 오기
        ThrowRabbits.SetActive(true);
        Invoke("HurtOne", 4f);
        // 시야줄어들기
    }

    private void HurtOne()
    {
        Debug.Log("Hurt 1");
        MainCharAnim.SetInteger("hurt", 1);
        Invoke("HurtTwo", 4f);
    }

    private void HurtTwo()
    {
        Debug.Log("Hurt 2");
        MainCharAnim.SetInteger("hurt", 2);
        Invoke("HurtThree", 4f);
    }

    private void HurtThree()
    {
        Debug.Log("Hurt 3");
        MainCharAnim.SetInteger("hurt", 3);
    }
}
