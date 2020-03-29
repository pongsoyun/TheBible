﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int waveLimit;
    public int killCount;
    public Vector2 throwPower;
    public Vector3 rotateAngle;
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
    }

    private void InitializeGame()
    {
        state = GameState.Start;
        state = GameState.OnGoing;
        waveLimit = 40;
        killCount = 0;
        StonePool = new MemoryPool(StonePrefab, 10, 20);
        StartCoroutine(StoneSpawn());
    }

    private void GameClear()
    {
        state = GameState.Clear;
        StopCoroutine(StoneSpawn());
    }

    private void GameFail()
    {
        state = GameState.Fail;
        StopCoroutine(StoneSpawn());
    }

    IEnumerator StoneSpawn()
    {
        while (state.Equals(GameState.OnGoing))
        {
            if (killCount < waveLimit)
            {
                rotateAngle.z = UnityEngine.Random.Range(-15.0f, 15.0f);
                gameObject.transform.Rotate(rotateAngle);
                //gameObject.transform.eulerAngles = new Vector3(0f, 0f, Mathf.Clamp(gameObject.transform.eulerAngles.z, -45f, -75f));
                throwPower = TargetObject.transform.position - gameObject.transform.position;
                throwPower.Normalize();
                StonePool.Respawn(transform.position, transform.rotation);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                Debug.Log("GameEnd!");
                GameClear();
                yield return new WaitForEndOfFrame();
            }
        }

    }
}