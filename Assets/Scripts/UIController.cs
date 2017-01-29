using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameController gc;
    public GameObject gameOverSreen;
    public Color[] colors;

    public Text time;
    public Text score;

    public Text gameOverScore;


    void Start()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GameOverEvent += GameOver;
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
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Jump())
            GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = colors[newColor];
    }


    void GameOver()
    {
        Debug.Log("Final Game Over");
        gameOverSreen.GetComponent<Canvas>().enabled = true;
        GetComponent<Canvas>().enabled = false;
    }


    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
