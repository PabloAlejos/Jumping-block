using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Image blocker;
    public GameController gc;
    public GameObject inGameScreen;
    public GameObject gameOverSreen;
    Color[] colors;
    public Text time;
    public Text score;

    public Text gameOverScore;


    void Start()
    {
        colors = FindObjectOfType<Player>().colors;
        GameObject.FindObjectOfType<GameController>().GetComponent<GameController>().GameOverEvent += GameOver;
    }



    void Update()
    {
        if (GetComponent<Canvas>().isActiveAndEnabled)
        {
            time.text = gc.remainingTime.ToString("00.00");
            score.text = gc.score.ToString();
            gameOverScore.text = gc.score.ToString();
        }

    }

    public void SetPlayerColor(int newColor)
    {
        if (GameObject.FindObjectOfType<Player>().GetComponent<PlayerController>().Jump())
            GameObject.FindObjectOfType<Player>().GetComponent<Renderer>().material.color = colors[newColor];
    }


    void GameOver()
    {
        Debug.Log("Final Game Over");
        gameOverSreen.SetActive(true);
        inGameScreen.SetActive(false);
    }


    public void LoadScene(int i)
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(i);
    }

    public void SetBlocker(bool state)
    {
        blocker.gameObject.SetActive(state);
    }
}
