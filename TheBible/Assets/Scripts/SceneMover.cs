using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMover : MonoBehaviour
{
    public bool isPortalScene;

    [SerializeField]
    string sceneName;
    [SerializeField]
    int loadingImageIndex;

    bool sceneStart = false;
    public GameObject MGIntroObjs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!sceneStart && !isPortalScene && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.mainBGM.Pause();
            sceneStart = true;
            MGIntroObjs.SetActive(false);
            GameManager.instance.Player.SetActive(false);
            LoadingScene.SetGuideImageIndex(loadingImageIndex);
            LoadingScene.LoadScene(sceneName);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!sceneStart && isPortalScene && Input.GetKeyDown(KeyCode.W) && collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.mainBGM.Pause();
            GameManager.instance.Player.SetActive(false);
            sceneStart = true;
            LoadingScene.SetGuideImageIndex(loadingImageIndex);
            LoadingScene.LoadScene(sceneName);
        }
    }
}
