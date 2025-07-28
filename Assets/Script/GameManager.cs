using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager GetInstance { get { return instance; } }
    FlyUiManager uiManager;
    public FlyUiManager GetUIManagerInstance { get { return uiManager; } }
    private int bestScore = 0;
    private int currentScore = 0;
    private void Awake()
    {
        instance = this;
        uiManager = GameObject.FindObjectOfType<FlyUiManager>();
    }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");

        uiManager.BestScore(bestScore);
        uiManager.UpdateScore(0);
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        uiManager.SetRestart();

        if (bestScore < currentScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        uiManager.SetStart();
    }
    public void BackGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
