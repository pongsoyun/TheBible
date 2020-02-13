using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text GameOverText;
    // stage 1
    public GameObject Player;
    public float gameOverY = -30.0f;

    void Start()
    {
        // GameEventManager.GameOver = true; // 추후에 상태로 관리할 예정이라면
        GameOverText.enabled = false; // default 설정
    }


    // Update is called once per frame
    void Update()
    {
        // Game Over 출력
        if (Player.transform.localPosition.y < gameOverY)
        {
            Debug.Log("gameover");
            GameOver();
        }
    }

    private void GameOver()
    {
        GameOverText.enabled = true;
    }
}
