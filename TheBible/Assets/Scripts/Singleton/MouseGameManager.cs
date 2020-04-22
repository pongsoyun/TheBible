﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseGameManager : Singleton<MouseGameManager>, IGameProcess
{
    public event Action GameStart;
    public event Action GameComplete;
    public event Action GameOver;

    [SerializeField]
    private GameObject StonePrefab;
    [SerializeField]
    private GameObject TargetObject;
    GameState state;
    public MemoryPool StonePool;

    public int playerHp;
    public int waveLimit;
    public int killCount;
    public Vector2 throwPower;
    public Vector3 rotateAngle;

    bool sceneEnd = false;

    public Animator MainCharAnim;
    public Animator MiniRBAnim1;
    public Animator MiniRBAnim2;
    bool isMainCharMagic = false;
    void Awake()
    {
        GameStart += InitializeGame;
        GameComplete += GameClear;
        GameOver += GameFail;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        StoneSpawn();
        //Test Code
        if (!sceneEnd && Input.GetMouseButtonDown(1))//마우스 우클릭
        {
            sceneEnd = true;
            Debug.Log($"SceneEnd : {sceneEnd}");
            StonePool.Dispose();
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MouseClickGame"));
        }
        if (!sceneEnd && playerHp <= 0)
        {
            GameFail();
        }
    }

    private void InitializeGame()
    {
        state = GameState.Start;
        state = GameState.OnGoing;
        waveLimit = 10;
        killCount = 0;
        playerHp = 10;
        StonePool = new MemoryPool(StonePrefab, 10, 20);
        StartCoroutine(StoneSpawn());
    }

    private void GameClear()
    {
        state = GameState.Clear;
        Debug.Log($"{state}");
        Invoke("UnloadScene", 5f);
        StonePool.AllDespawn();
        StonePool.Dispose();
        StopCoroutine(StoneSpawn());
    }

    private void GameFail()
    {
        state = GameState.Fail;
        StopCoroutine(StoneSpawn());
        sceneEnd = true;
        Debug.Log($"SceneEnd : {sceneEnd}, GameState.{state}");
        StonePool.AllDespawn();
        StonePool.Dispose();
        Invoke("UnloadScene", 5f);
        Debug.Log("UnloadScene Call!");
    }

    IEnumerator StoneSpawn()
    {
        while (state.Equals(GameState.OnGoing))
        {
            if (!isMainCharMagic)
            {
                isMainCharMagic = true;
                MainCharAnim.SetBool("magic", true);
                MiniRBAnim1.SetBool("clear", false);
                MiniRBAnim2.SetBool("clear", false);
            }
            if (killCount < waveLimit)
            {
                rotateAngle.z = UnityEngine.Random.Range(-5.0f, 5.0f);
                gameObject.transform.Rotate(rotateAngle);
                //gameObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Clamp(gameObject.transform.eulerAngles.z, -45f, -75f));
                throwPower = TargetObject.transform.position - gameObject.transform.position;
                throwPower.Normalize();
                StonePool.Respawn(transform.position, transform.rotation);
                yield return new WaitForSeconds(3f);
            }
            else
            {
                MainCharAnim.SetBool("magic", false);
                MiniRBAnim1.SetBool("clear", true);
                MiniRBAnim2.SetBool("clear", true);
                isMainCharMagic = false;
                Debug.Log("GameEnd!");
                GameClear();
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MouseClickGame"));
    }
}