using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMover : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    bool sceneStart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!sceneStart && collision.gameObject.CompareTag("Player"))
        {
            sceneStart = true;
            LoadingScene.LoadScene(sceneName);
        }
    }
}
