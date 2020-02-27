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
    public List<MemoryPool> EnemyWavePool;
    public Transform SpawnPoint;
    private int waveCount = 3;
    private int enemyCount = 15;
    private int killCount = 0;

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
        if (state.Equals(GameState.Start))
        {
            state = GameState.OnGoing;
            StartCoroutine(WaveSpawn());
        }

        Debug.Log($"GameState : {state.ToString()}");
        WaveSpawn();
    }

    private void InitializeGame()
    {
        DebugPanel.SetActive(true);
        state = GameState.Start;
        Debug.Log($"GameState : {state.ToString()}");
        //EnemyPool = new MemoryPool(EnemyPrefab, 5, enemyCount);
        EnemyWavePool = new List<MemoryPool>(waveCount);
        EnemyWavePool[0] = new MemoryPool(EnemyPrefab, 5, enemyCount);
    }

    private void GameClear()
    {

    }

    private void GameFail()
    {

    }

    IEnumerator WaveSpawn()
    {
        for(int waveIndex = 0; waveIndex < waveCount;)
        {
            while (state.Equals(GameState.OnGoing) && killCount < (waveIndex + 1) * waveCount)
            {
                //EnemyPool.Respawn(SpawnPoint.position, gameObject.transform.rotation);
                EnemyWavePool[waveIndex].Respawn(SpawnPoint.position, gameObject.transform.rotation);
                Debug.Log($"Current Wave : {waveIndex}, Kill Count/End Line : {killCount}/{(waveIndex + 1) * waveCount} ,Spawn Prefab");
                if (killCount.Equals((waveIndex + 1) * waveCount))
                {
                    DeleteWave(EnemyWavePool[waveIndex]);
                    waveIndex++;
                    InitializeWave(EnemyWavePool[waveIndex], waveIndex);
                }
                yield return new WaitForSeconds(waveCount - waveIndex);
            }
        }
    }

    private void InitializeWave(MemoryPool enemyPool, int waveIndex)
    {
        enemyPool = new MemoryPool(EnemyPrefab, 5 * waveIndex, enemyCount * waveIndex);
    }

    private void DeleteWave(MemoryPool enemyPool)
    {
        enemyPool.AllDespawn();
        enemyPool.Dispose();
    }

}
