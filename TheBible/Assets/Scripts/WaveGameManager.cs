using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameState
{
    Start,
    OnGoing,
    Clear,
    Fail
}
public class WaveGameManager : Singleton<WaveGameManager> , IGameProcess
{
    public event Action GameStart;
    public event Action GameComplete;
    public event Action GameOver;

    [SerializeField]
    private GameObject DebugPanel;
    public Text DebugText;
    [SerializeField]
    GameObject EnemyPrefab;
    GameState state;
    public MemoryPool EnemyPool;
    public Transform SpawnPoint;
    void Awake()
    {
        GameStart += InitializeGame;
        GameComplete += GameClear;
        GameOver += GameFail;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameStart?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(state.Equals(GameState.Start))
            state = GameState.OnGoing;
        Debug.Log($"GameState : {state.ToString()}");
        WaveSpawn();
    }

    private void InitializeGame()
    {
        DebugPanel.SetActive(true);
        state = GameState.Start;
        Debug.Log($"GameState : {state.ToString()}");
        EnemyPool = new MemoryPool(EnemyPrefab, 5, 15);
        StartCoroutine(WaveSpawn());
    }

    private void GameClear()
    {

    }

    private void GameFail()
    {

    }

    IEnumerator WaveSpawn()
    {
        while(state.Equals(GameState.OnGoing))
        {
            EnemyPool.Respawn(SpawnPoint.position, gameObject.transform.rotation);
            Debug.Log("Spawn Prefab");
            yield return new WaitForSeconds(1.5f);
        }
        
    }
}
