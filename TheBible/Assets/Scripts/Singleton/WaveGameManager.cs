using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum GameState
{
    Start,
    OnGoing,
    Clear,
    Fail
}

public class WaveGameManager : Singleton<WaveGameManager>, IGameProcess
{
    public event Action GameStart;
    public event Action GameComplete;
    public event Action GameOver;
    public Text DebugText;

    [SerializeField]
    private GameObject DebugPanel;
    [SerializeField]
    GameObject[] EnemyPrefab;
    [SerializeField]
    GameObject ParticlePrefab;
    [SerializeField]
    private int waveLimit;

    GameState state;
    public MemoryPool[] EnemyWavePool;
    public MemoryPool ParticlePool;
    public Transform SpawnPoint;
    public int killCount = 0;

    private int enemyCount = 15;
    private WaitForSeconds waitTime = new WaitForSeconds(2.5f);
    private bool sceneEnd = false;

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
        // Game Start
        if (state.Equals(GameState.Start))
        {
            state = GameState.OnGoing;
            StartCoroutine(WaveSpawn());
        }
        else if (state.Equals(GameState.OnGoing))
        {
            WaveSpawn();
            RenderPlayerHp();
        }
        else if (state.Equals(GameState.Fail))
        {
            Invoke("GameFail", 2f);
        }
        else if (state.Equals(GameState.Clear))
        {
            DebugText.text = "Game Clear!";
            Invoke("GameClear", 2f);
        }
        Debug.Log($"GameState : {state.ToString()}");

        //Test Code
        if (!sceneEnd && Input.GetMouseButtonDown(1))//마우스 우클릭
        {
            sceneEnd = true;
            Debug.Log($"SceneEnd : {sceneEnd}");
            DisposeAllPool();
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("WaveGame"));
        }
    }

    private void InitializeGame()
    {
        DebugPanel.SetActive(true);
        state = GameState.Start;
        Debug.Log($"GameState : {state.ToString()}");
        EnemyWavePool = new MemoryPool[EnemyPrefab.Length];
        EnemyWavePool[0] = new MemoryPool(EnemyPrefab[0], 5, enemyCount);
        EnemyWavePool[1] = new MemoryPool(EnemyPrefab[1], 5, enemyCount);
        ParticlePool = new MemoryPool(ParticlePrefab, 5, enemyCount * 2);
        waveLimit = 10;
    }

    private void GameClear()
    {
        sceneEnd = true;
        DisposeAllPool();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("WaveGame"));
    }

    private void GameFail()
    {
        sceneEnd = true;
        Debug.Log($"SceneEnd : {sceneEnd}");
        DisposeAllPool();
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("WaveGame"));
    }

    IEnumerator WaveSpawn()
    {
        while (state.Equals(GameState.OnGoing))
        {
            int rabbitSize = Random.Range(0, EnemyPrefab.Length);
            if (killCount < waveLimit)
            {
                EnemyWavePool[rabbitSize].Respawn(SpawnPoint.position, gameObject.transform.rotation);
                yield return waitTime;
            }
            else if (killCount >= waveLimit)
            {
                DebugText.text = "Game Over!";
                state = GameState.Clear;
                yield return new WaitForEndOfFrame();
            }
            else
            {
                Debug.Log("Coroutine return null");
                yield return null;
            }
        }
        Debug.Log($"{gameObject.name} : End Coroutine!");
    }

    private void RenderPlayerHp()
    {
        int playerHp = GamePlayerMove.instance.playerHP;

        if (playerHp <= 0)
        {
            DebugText.text = "Game Over!";
            state = GameState.Fail;
            return;
        }
        DebugText.text = $"Player Hp : {playerHp}";
    }

    private void DisposeAllPool()
    {
        foreach (var pool in EnemyWavePool)
        {
            //pool.AllDespawn();
            pool.Dispose();
        }
        foreach (var pool in GamePlayerMove.instance.throwObjectPool)
        {
            //pool.AllDespawn();
            pool.Dispose();
        }
        ParticlePool.Dispose();
    }
}
