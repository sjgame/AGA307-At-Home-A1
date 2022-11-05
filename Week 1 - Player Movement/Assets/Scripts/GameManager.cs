using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public enum GameState { Title, Playing, Paused, GameOver }

public enum Difficulty { Easy, Medium, Hard }



public class GameManager : Singleton<GameManager>
{
    public static event Action<Difficulty> OnDifficultyChanged = null;

    

    public GameState gameState;
    public Difficulty difficulty;
    public int score;
    int scoreMultiplyer;
    public float timer;
    float plusTimer;


    public float damage;

    public void Start()
    {
        timer = 30;
        Setup();
        OnDifficultyChanged?.Invoke(difficulty);
        //AddTime();
        

    }
    public void Update()
    {
        if (gameState == GameState.Playing)
        {
            timer -= Time.deltaTime;
            _UI.UpdateTimer(timer);
        }
  
    }
    void Setup()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplyer = 1;
                break;
            case Difficulty.Medium:
                scoreMultiplyer = 2;
                break;
            case Difficulty.Hard:
                scoreMultiplyer = 3;
                break;
        }
    }
    //public void AddTime()
    //{
    //    plusTimer = GetComponent<Target>().health;
    //    if (plusTimer <= 0f)
    //    {
    //        timer += 50f;
            
    //    }
    //}

    public void AddScore(int _score)
    {
        score += _score * scoreMultiplyer;
        print("score");
        _UI.UpdateScore(score);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeDifficulty(int _difficulty)
    {
        difficulty = (Difficulty)_difficulty;
        Setup();
    }

    private void OnEnable()
    {
        Target.OnEnemyHit += OnEnemyHit;
        Target.OnEnemyDie += OnEnemyDie;
    }

    private void OnDisable()
    {
       Target.OnEnemyHit -= OnEnemyHit;
       Target.OnEnemyDie -= OnEnemyDie;
    }

    void OnEnemyHit(GameObject _enemy)
    {
        AddScore(10);
    }
    void OnEnemyDie(GameObject _enemy)
    {
        AddScore(100);
    }
}
