using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Instance sebagai global access
    public static GameManager instance;
    public int playerScore;
    public Text scoreText;
    public int timer;
    public Text timerText;
    public GameObject panel;
    public Text endScore;
    public Text comboText;

    // singleton
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        StartCoroutine(CountTimer());
    }

    //Update score dan ui
    public void GetScore(int point)
    {
        playerScore += point;
        scoreText.text = playerScore.ToString();
    }

    IEnumerator CountTimer()
    {
        while (timer >= 0)
        {
            timerText.text = timer.ToString();
            timer--;
            yield return new WaitForSeconds(1f);
        }
        GameOver();
    }

    void GameOver()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        endScore.text = "Score : " + playerScore.ToString();
    }

    public void DisplayCombo(int value)
    {
        comboText.text = value.ToString() + "x";
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadScene("SampleScene");
        SceneManager.LoadScene("SampleScene");
    }
}
