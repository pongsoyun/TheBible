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

    [SerializeField]
    private GameObject DebugPanel;
    public Text DebugText;
    [SerializeField]
    GameObject[] EnemyPrefab;
    GameState state;
    public MemoryPool[] EnemyWavePool;
    public Transform SpawnPoint;
    public int killCount = 0;
    public int ActiveEnemyCount = 0;

    private int enemyCount = 15;
    private int waveLimit;
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
            Invoke("GameFail", 5f);
        }

        Debug.Log($"GameState : {state.ToString()}");

        //Test Code
        if (!sceneEnd && Input.GetMouseButtonDown(1))//마우스 우클릭
        {
            sceneEnd = true;
            Debug.Log($"SceneEnd : {sceneEnd}");
            //LoadingScene.LoadScene("Stage1");
            foreach (var pool in EnemyWavePool)
            {
                //pool.AllDespawn();
                pool.Dispose();
            }
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("WaveGame"));
        }
    }

    private void InitializeGame()
    {
        DebugPanel.SetActive(true);
        state = GameState.Start;
        Debug.Log($"GameState : {state.ToString()}");
        EnemyWavePool = new MemoryPool[EnemyPrefab.Length];
        EnemyWavePool[0] = new MemoryPool(EnemyPrefab[0], 5, enemyCount * 2);
        EnemyWavePool[1] = new MemoryPool(EnemyPrefab[1], 5, enemyCount);
    }

    private void GameClear()
    {

    }

    private void GameFail()
    {
        SceneManager.UnloadSceneAsync("WaveGame");
    }

    IEnumerator WaveSpawn()
    {
        while (state.Equals(GameState.OnGoing))
        {
            waveLimit = 30;
            int rabbitSize = Random.Range(0, EnemyPrefab.Length);
            if (killCount < waveLimit && ActiveEnemyCount < waveLimit)
            {
                EnemyWavePool[rabbitSize].Respawn(SpawnPoint.position, gameObject.transform.rotation);
                yield return waitTime;
            }
            else
            {
                state = GameState.Clear;
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
}
