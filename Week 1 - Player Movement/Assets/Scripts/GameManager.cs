using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public VariedSize currentSize;
    public float scaleFactor;
    public Image timeFill;
    public float timeLeft;
    public int enemyCount;

    public float damage;

    public void Start()
    {
        timer = 30;
        Setup();
        OnDifficultyChanged?.Invoke(difficulty);
        timeLeft = timer;
        
    }
    public void Update()
    {
        if (gameState == GameState.Playing)
        {
            timer -= Time.deltaTime;
            _UI.UpdateTimer(timer);
            timeFill.fillAmount = timer / timeLeft;
            
        }

    }
   
    void Setup()
    {
        //sets up our difficulty enum that can be switched. Each difficulty has set parameters.
        switch (difficulty)
        {
            case Difficulty.Easy:
                scoreMultiplyer = 1;
                currentSize = VariedSize.Small;
                break;
            case Difficulty.Medium:
                scoreMultiplyer = 2;
                currentSize = VariedSize.Medium;
                break;
            case Difficulty.Hard:
                scoreMultiplyer = 3;
                currentSize = VariedSize.Large;
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
        //adds score and updates our UI with the new score. 
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
        //Changes the difficuly of our game set in the switch.
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
        //When an enemy is hit add 10 to score and time to timer.
        AddScore(10);
        timer += 1f;
    }
    public void OnEnemyDie(GameObject _enemy)
    {
        //When enemy dies add 100 score and extra time.
        AddScore(100);
        timer += 4f;
        //_UI.UpdateEnemyCount();
        
    }
}
