using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text GameOverText;
    // Tutorial
    public bool isTutorial = true;
    // stage 1
    public GameObject Player;
    public float gameOverY = -30.0f;

    public Transform Flag1;

    public bool isGameOver;

    void Start()
    {
        GameOverText.enabled = false; // default 설정
        isGameOver = false;
    }


    // Update is called once per frame
    void Update()
    {
        // GameOver
        if (!isGameOver && Player.transform.localPosition.y < gameOverY)
        {
            Debug.Log("gameover");
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        GameOverText.enabled = true;
        Invoke("MovingSpawnSpot", 3f);
    }

    private void MovingSpawnSpot()
    {
        Player.transform.position = new Vector3(Flag1.position.x, Flag1.position.y, Flag1.position.z);
        isGameOver = false;
        GameOverText.enabled = false;

        // 좀 더 부드럽게 가져오려 했는데 우선은,,, 기본구현부터푸쉬,, 
        // Vector3 flag1Down = new Vector3(Flag1Down.position.x, Flag1Down.position.y, Flag1Down.position.z);
        // Player.transform.position = Vector3.MoveTowards(transform.position, flag1Down, 2f); 
    }
}
