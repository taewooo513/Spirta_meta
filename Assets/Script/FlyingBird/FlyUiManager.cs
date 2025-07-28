using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyUiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestScoreText;
    public GameObject startUI;

    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
        {
            Debug.Log("����ŸƮ ����");
        }

        if (scoreText == null)
        {
            Debug.Log("���ھ� ����");
        }

        restartText.gameObject.SetActive(false);

    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void SetStart()
    {
        startUI.gameObject.SetActive(false);
    }
    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void BestScore(int score)
    {
        bestScoreText.text = score.ToString();
    }
}
