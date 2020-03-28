using System;
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
    GameState state;
    public MemoryPool StonePool;

    public int waveLimit;
    public int killCount;

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
        StonePool = new MemoryPool(StonePrefab, 10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeGame()
    {
        state = GameState.Start;
        waveLimit = 40;
        killCount = 0;
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
                StonePool.Respawn(transform.position, transform.rotation);
                yield return new WaitForSeconds(0.2f);
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