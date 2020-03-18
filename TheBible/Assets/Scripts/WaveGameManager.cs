using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public MemoryPool EnemyWavePool;
    public Transform SpawnPoint;
    public int killCount = 0;
    public int ActiveEnemyCount = 0;
    private int waveIndex;
    private int waveCount = 3;
    private int enemyCount = 15;
    private int waveLimit;

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
        EnemyWavePool = new MemoryPool(EnemyPrefab, 5, enemyCount * waveCount * 3);
    }

    private void GameClear()
    {

    }

    private void GameFail()
    {

    }

    IEnumerator WaveSpawn()
    {
        while (state.Equals(GameState.OnGoing))
        {
            waveLimit = (waveIndex + 1) * waveCount;
            if (killCount < waveLimit && ActiveEnemyCount < waveLimit)
            {
                EnemyWavePool.Respawn(SpawnPoint.position, gameObject.transform.rotation);
                Debug.Log($"WaveIndex : {waveIndex}, Kill Count/End Line : {killCount}/{waveLimit}");

                yield return new WaitForSeconds(waveCount + 1 - waveIndex);
            }
            else
            {
                Debug.Log("WaitForEndWave");
                if (killCount.Equals(waveLimit))
                {
                    killCount = 0;
                    waveIndex++;
                    Debug.Log($"Next Wave : {waveIndex}, Kill Count/End Line : {killCount}/{waveLimit}");
                }
                yield return new WaitForEndOfFrame();
            }
        }
        Debug.Log("End Coroutine!");
        //SceneManager.LoadScene("WaveGame", LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("WaveGame"));
        SceneManager.UnloadSceneAsync("WaveGame");
    }

}
