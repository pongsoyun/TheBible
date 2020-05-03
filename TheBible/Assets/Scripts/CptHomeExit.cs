using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CptHomeExit : MonoBehaviour
{
    public Animator KingAnimator;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (KingAnimator.GetBool("Cure") && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("CptHome"));
        }
    }
}
