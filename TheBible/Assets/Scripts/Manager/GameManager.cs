using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Text GameOverText;
    // Tutorial
    public bool isTutorial = true;
    // stage 1
    public GameObject Player;

    public float gameOverX;
    public float gameOverY = -30.0f;

    [Header("Flag"), Space(5)]
    public Transform FlagPond;
    public Transform FlagCliff;
    public Transform FlagTown;
    public Transform FlagMiniGame1;
    public Transform FlagMiniGame2;
    public Transform FlagBigHouse;
    
    public bool isGameOver;
    [SerializeField, Header("FlimBar"), Space(5)]
    GameObject[] filmBar;

    [SerializeField]
    GameObject GameOverSound;

    void Start()
    {
        GameOverText.enabled = false; // default 설정
        isGameOver = false;
        GameOverSound.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // GameOver
        if (!isGameOver && (Player.transform.localPosition.y < this.gameOverY))
        {
            Debug.Log("gameover");
            GameOverSound.SetActive(true);
            GameOver(Player.transform.localPosition.x);
        }
        else
        {
            // GameOverSound.SetActive(false);
        }
    }

    private void GameOver(float gameOverX)
    {
        this.gameOverX = gameOverX;
        isGameOver = true;
        GameOverText.enabled = true;

        Invoke("MovingSpawnSpot", 3f);
    }

    private void MovingSpawnSpot()
    {
        GameOverSound.SetActive(false);
        if (gameOverX < FlagCliff.position.x)
        {
            // FlagPond에서 죽었을 경우
            Player.transform.position = new Vector3(FlagPond.position.x, FlagPond.position.y, FlagPond.position.z);
        }
        else if (gameOverX < FlagTown.position.x)
        {
            // FlagCliff에서 죽었을 경우
            Player.transform.position = new Vector3(FlagCliff.position.x, FlagCliff.position.y, FlagCliff.position.z);
        }
        else if (gameOverX < FlagMiniGame2.position.x)
        {
            // FlagMiniGame1에서 죽었을 경우
            Player.transform.position = new Vector3(FlagMiniGame1.position.x, FlagMiniGame1.position.y, FlagMiniGame1.position.z);
        }
        else if (gameOverX < FlagBigHouse.position.x)
        {
            // FlagMiniGame2에서 죽었을 경우
            Player.transform.position = new Vector3(FlagMiniGame2.position.x, FlagMiniGame2.position.y, FlagMiniGame2.position.z);
        }

        // Player.transform.position = new Vector3(FlagStart.position.x, FlagStart.position.y, FlagStart.position.z);
        isGameOver = false;
        GameOverText.enabled = false;

        // 좀 더 부드럽게 가져오려 했는데 우선은,,, 기본구현부터푸쉬,, 
        // Vector3 flag1Down = new Vector3(Flag1Down.position.x, Flag1Down.position.y, Flag1Down.position.z);
        // Player.transform.position = Vector3.MoveTowards(transform.position, flag1Down, 2f); 
    }

    public void FilmBarOn(PlayableDirector playableDirector)
    {
        Debug.Log("Check FilmBarOn Call Stack");
        foreach(var bar in filmBar)
        {
            bar.SetActive(true);
        }
    }

    public void FilmBarOff(PlayableDirector playableDirector)
    {
        Debug.Log("Check FilmBarOff Call Stack");
        foreach (var bar in filmBar)
        {
            bar.SetActive(false);
        }
    }
}
