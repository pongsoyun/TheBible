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
    [SerializeField]
    private GameObject ParticleObject;

    GameState state;
    public MemoryPool StonePool;
    public MemoryPool ParticlePool;
    public int playerHp;
    public int waveLimit;
    public int killCount;
    public Vector2 throwPower;
    public Vector3 rotateAngle;

    bool sceneEnd = false;

    public Animator MainCharAnim;
    public Animator MiniRBAnim1;
    public Animator MiniRBAnim2;
    public Animator BigRbAnim;
    bool isMainCharMagic = false;
    public AudioSource mg2BGM;
    void Awake()
    {
        GameStart += InitializeGame;
        GameComplete += GameClear;
        GameOver += GameFail;
    }

    // Start is called before the first frame update
    void Start()
    {
        mg2BGM.Play();
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
            UnloadScene();
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
        StonePool = new MemoryPool(StonePrefab, 5, 10);
        ParticlePool = new MemoryPool(ParticleObject, 5, 10);
        StartCoroutine(StoneSpawn());
    }

    private void GameClear()
    {
        state = GameState.Clear;
        Debug.Log($"{state}");
        sceneEnd = true;
        StopCoroutine(StoneSpawn());
        Invoke("UnloadScene", 5f);
    }

    private void GameFail()
    {
        state = GameState.Fail;
        sceneEnd = true;
        StopCoroutine(StoneSpawn());
        Debug.Log($"SceneEnd : {sceneEnd}, GameState.{state}");
        Invoke("UnloadScene", 5f);
    }

    IEnumerator StoneSpawn()
    {
        while (state.Equals(GameState.OnGoing))
        {
            if (!isMainCharMagic)
            {
                isMainCharMagic = true;
                MainCharAnim.SetBool("magic", true);
                // MiniRBAnim1.SetBool("clear", false);
                // MiniRBAnim2.SetBool("clear", false);
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
                BigRbAnim.SetBool("clear", true);
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
        GameManager.instance.mainBGM.Play();
        Debug.Log("UnloadScene Call!");
        StonePool.Dispose();
        ParticlePool.Dispose();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MouseClickGame"));
    }
}