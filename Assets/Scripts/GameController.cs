using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public delegate void GameControllerEvent();
    public event GameControllerEvent GameOverEvent;

    public float remainingTime = 60;
    public float score = 0;
    bool newSpawn = false;
    public GameObject spawner;
    public GameObject platePrefab;





    void Start()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().jumpEvent += SpawnPlate;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().successEvent += AddScore;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().failEvent += TimePenalty;
        Instantiate(platePrefab, spawner.transform.position, Quaternion.identity);
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
        GameOverEvent();
    }

    void TimePenalty(float timeInSecs)
    {
        remainingTime -= timeInSecs;
        Debug.Log("resta");
    }


    void AddScore(float value)
    {
        score += value;
    }

}
