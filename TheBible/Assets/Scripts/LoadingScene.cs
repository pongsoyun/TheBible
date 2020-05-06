using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    Image loadingBar;
    [SerializeField]
    Text guideText;
    [SerializeField]
    Image testImage;
    [SerializeField]
    Sprite[] guideSprite;

    static int guideImageIndex = 0;
    static string SceneName = "Stage1";//private?

    // Start is called before the first frame update
    void Start()
    {
        testImage.sprite = guideSprite[guideImageIndex];
        loadingBar.fillAmount = 0;
        StartCoroutine(LoadAsyncScene());
    }

    public static void LoadScene(string sceneName)
    {
        SceneName = sceneName;
        if (SceneManager.GetSceneByName(SceneName).Equals(null))
        {
            Debug.LogError("This Scene Not Exists!");
        }
        else
        {
            SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);
        }
    }
    public static void SetGuideImageIndex(int index)
    {
        guideImageIndex = index;
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;

        var asyncScene = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        asyncScene.allowSceneActivation = false;
        float timeC = 0;

        while (!asyncScene.isDone)
        {
            yield return null;
            timeC += Time.deltaTime;

            if (asyncScene.progress >= 0.9f)
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, 1, timeC);
                if (loadingBar.fillAmount.Equals(1.0f))
                {
                    guideText.text = "아무 키나 누르면 다음으로 넘어갑니다.";
                    if (Input.anyKeyDown)
                    {
                        //yield return new WaitForSeconds(2.0f); // For Fake Loading
                        asyncScene.allowSceneActivation = true;
                        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("LoadingScene"));
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
                    }
                }
            }
            else
            {
                loadingBar.fillAmount = Mathf.Lerp(loadingBar.fillAmount, asyncScene.progress, timeC);
                if (loadingBar.fillAmount >= asyncScene.progress)
                    timeC = 0f;
            }
        }
    }
}
