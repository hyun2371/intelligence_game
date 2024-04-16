using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class GameDirector : MonoBehaviour
{
    GameObject scoreText;
    GameObject ghostText;
    GameObject hpGauge;
    GameObject ghostLife;
    GameObject ghost;
    public GameObject endPanel;
    AudioSource hurtSound;
    int score;
    int remainCount;

    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
        this.ghostLife = GameObject.Find("ghostLife");
        this.scoreText = GameObject.Find("scoreText");
        this.ghostText = GameObject.Find("ghostText");
        this.hurtSound = GameObject.Find("BallGenerator").GetComponent<AudioSource>();
        this.ghost = GameObject.Find("ghost");
        this.score = 0;
        this.remainCount = 20;
    }

    void Update()
    {
        DisplayCoinText();
        DisplayGhostText();
        ManageGhostLife();
        ManageGameStatus();
    }

    private void ManageGameStatus()
    {
        if (this.hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            GameOver();
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void ManageGhostLife()
    {
        if (Input.GetMouseButtonDown(2) && remainCount > 0)
        {
            this.remainCount--;
            this.ghostLife.GetComponent<Image>().fillAmount -= 0.05f;
            if (this.remainCount == 10)
            {
                this.ghost.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            if (this.remainCount == 5)
            {
                this.ghost.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
            if (this.remainCount == 0)
            {
                ghost.SetActive(false);
                ghostText.SetActive(false);
                GameObject.Find("gate").SetActive(false);
            }
        }
    }

    private void DisplayCoinText()
    {
        this.scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
    }

    private void DisplayGhostText()
    {
        
        ghostText.GetComponent<TextMeshProUGUI>().text = "click mouse middle button to remove the ghost.\nremain count:" + remainCount;
        
    }

    public void IncreaseScore(int value)
    {
        this.score += value;
    }

    public void decreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void increaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount += 0.1f;
    }

    public void increaseHp(float value)
    {
        this.hpGauge.GetComponent<Image>().fillAmount += value;
    }

    public void resetHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount = 1.0f;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        this.endPanel.SetActive(true);
        GameObject.Find("panelText").GetComponent<TextMeshProUGUI>().text = "Well Played! \n Score: " + score;
        this.hurtSound.volume = 0;
        Invoke("Restart", 3f);

    }

    public void EndGame()
    {
        Debug.Log("Goal");
        this.endPanel.SetActive(true);
        GameObject.Find("panelText").GetComponent<TextMeshProUGUI>().text = "You've reached the goal! \n Score: " + score;

        Invoke("Restart", 3f);

    }

    public void Restart()
    {
        SceneManager.LoadScene("midterm");
    }
}
