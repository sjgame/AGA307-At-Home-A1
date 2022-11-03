using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : Singleton<UI_Manager>
{
    // Start is called before the first frame update
    public TMP_Text scoreText;
    public TMP_Text enemyCountText;
    public TMP_Text difficultyText;
    public TMP_Text timerText;
    public TMP_Text weaponText;

    void Start()
    {
        UpdateScore(0);
        //UpdateWeapon(weaponText.text);
    }

    public void UpdateScore(int _score) //Display the score in TMP text
    {


        scoreText.text = "Score: " + _score; //Gets the score var from GameManager

    }
    public void UpdateEnemyCount(int _count)
    {
        enemyCountText.text = "Enemy Count: " + _count;
    }
    public void UpdateDifficulty(int _difficulty)
    {
        difficultyText.text = "Difficulty: " + _difficulty;
    }
    public void UpdateTimer(float _time)
    {
        timerText.text = _time.ToString("##.##");
    }

    //public void UpdateWeapon(string _weaponSelected)
    //{
    //    weaponText.text = _weaponSelected;
    //}
}

