using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    Image healthbar;  
    GameObject gameOverObject;
    GameObject mainMenuObject;
    public GameObject scoreText;
    public GameObject highScoreText;
    public int score = 0;
    public int highScore;

    void Start()
    {
        Time.timeScale = 0;
        healthbar = GameObject.FindGameObjectWithTag("Health").GetComponent<Image>();
        gameOverObject = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(0).gameObject;
        mainMenuObject = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).gameObject;
        gameOverObject.SetActive(false);
        mainMenuObject.SetActive(true);
    }
    void Update(){
        scoreText.GetComponent<TMP_Text>().text = "score: " + score;
        highScoreText.GetComponent<TMP_Text>().text = "high score: " + highScore;
    }

    public void OpenMainMenu(){
        gameOverObject.SetActive(false);
        mainMenuObject.SetActive(true);
    }
    public void OpenOptions(){

    }
    public void Quit(){

    }
    public void playGame(){
        Time.timeScale = 1;
        gameOverObject.SetActive(false);
        mainMenuObject.SetActive(false);
    }
    public void ResumeGameAfterGameOver(){
        Time.timeScale = 1;
        healthbar.fillAmount = 0.5f;
        gameOverObject.SetActive(false);
    }
}
