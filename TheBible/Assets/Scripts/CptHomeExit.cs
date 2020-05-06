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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!sceneEnd && KingAnimator.GetBool("cure") && Input.GetKeyDown(KeyCode.W))
        {
            sceneEnd = true;
            Player.GetComponent<CharacterMove>().enabled = false;
            Invoke("LatePlayerSetFalse", 1f);
            Invoke("UnloadCptScene", 7f);//7초 뒤에 씬 내리도록
        }
    }

    private void LatePlayerSetFalse()
    {
        Player.SetActive(false);
    }

    private void UnloadCptScene()
    {
        Debug.Log("UnloadScene Called!");
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("CptHome"));
    }
}
