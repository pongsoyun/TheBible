using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMover : MonoBehaviour
{
    public bool isPortalScene;

    [SerializeField]
    string sceneName;

    bool sceneStart = false;
    public GameObject MGIntroObjs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!sceneStart && !isPortalScene && collision.gameObject.CompareTag("Player"))
        {
            sceneStart = true;
            MGIntroObjs.SetActive(false);
            LoadingScene.LoadScene(sceneName);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!sceneStart && isPortalScene && Input.GetKeyDown(KeyCode.W) && collision.gameObject.CompareTag("Player"))
        {
            sceneStart = true;
            LoadingScene.LoadScene(sceneName);
        }
    }
}
