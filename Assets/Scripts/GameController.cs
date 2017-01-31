using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public delegate void GameControllerEvent();
    public event GameControllerEvent GameOverEvent;


    GameObject player;

    public float remainingTime = 60;
    public int score = 0;
    bool newSpawn = false;
    public GameObject spawner;
    public GameObject platePrefab;

    int highScore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().jumpEvent += SpawnPlate;
        player.GetComponent<PlayerController>().successEvent += AddScore;
        player.GetComponent<PlayerController>().failEvent += TimePenalty;


        Instantiate(platePrefab, spawner.transform.position, Quaternion.identity);
        highScore = PlayerPrefs.GetInt("highscore", highScore);
        Debug.Log(highScore);
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            GameOver();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (newSpawn)
        {
            Instantiate(platePrefab, spawner.transform.position, Quaternion.identity);
            newSpawn = false;
        }
    }

    void SpawnPlate()
    {
        newSpawn = true;
    }

    void GameOver()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            Debug.Log("New High score!: " + score);
        }
        GameOverEvent();
    }

    void TimePenalty(float timeInSecs)
    {
        remainingTime -= timeInSecs;
        Debug.Log("resta");
    }


    void AddScore(float value)
    {
        score += (int)value;
    }



}
