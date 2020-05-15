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
    [Header("FlimBar"), Space(5)]
    public GameObject[] filmBar;

    [SerializeField]
    public AudioSource gameOverSound;
    [SerializeField]
    public AudioSource mainBGM;

    void Start()
    {
        GameOverText.enabled = false; // default 설정
        isGameOver = false;
    }


    // Update is called once per frame
    void Update()
    {
        // GameOver
        if (!isGameOver && (Player.transform.localPosition.y < this.gameOverY))
        {
            Debug.Log("gameover");
            gameOverSound.Play();
            GameOver(Player.transform.localPosition.x);
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

        isGameOver = false;
        GameOverText.enabled = false;
    }

    public void FilmBarOn()
    {

    }

    void DisposeFlimBar()
    {

    }
    //public void FilmBarOff(PlayableDirector playableDirector)
    //{
    //    Debug.Log("Check FilmBarOff Call Stack");
    //    foreach (var bar in filmBar)
    //    {
    //        bar.SetActive(false);
    //    }
    //}
}
