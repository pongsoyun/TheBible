using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CptHomeExit : MonoBehaviour
{
    public Animator KingAnimator;
    private bool sceneEnd = false;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject BigTalkingBubble;

    private void Start()
    {
        BigTalkingBubble.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!sceneEnd && KingAnimator.GetBool("cure") && Input.GetKey(KeyCode.W))
        {
            // 수근수근이수근
            sceneEnd = true;
            GameManager.instance.isBeforeCpt = false;
            BigTalkingBubble.SetActive(true);
            Player.GetComponent<CharacterMove>().enabled = false;
            Invoke("LatePlayerSetFalse", 1f);
            Invoke("UnloadCptScene", 10f);//10초 뒤에 씬 내리도록

        }
    }

    private void LatePlayerSetFalse()
    {
        Player.SetActive(false);
    }

    private void UnloadCptScene()
    {
        Debug.Log("UnloadScene Called!");
        GameManager.instance.Player.SetActive(true);
        GameManager.instance.mainBGM.Play();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("CptHome"));
    }
}
