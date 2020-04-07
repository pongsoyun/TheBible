using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    public bool sceneLoad = false;

    void Start()
    {
        Debug.Log("Press W and then Scene Active");    
    }

    void Update()
    {
        if(!sceneLoad && Input.GetKeyDown(KeyCode.W))
        {
            sceneLoad = true;
            Debug.Log($"Scene Call! : {sceneLoad}");
            LoadingScene.LoadScene("WaveGame");
            transform.position = new Vector3(transform.position.x + 3, 0, 0);
            //SceneManager.LoadScene("WaveGame", LoadSceneMode.Additive);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("WaveGame"));
            Debug.Log($"Active Scene : {SceneManager.GetActiveScene().name}");

        }
    }
}
