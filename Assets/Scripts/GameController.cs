using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float remainingTime = 60;
    public float score = 0;
    bool newSpawn = false;
    public GameObject spawner;
    public GameObject platePrefab;

    // Use this for initialization
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().jumpEvent += SpawnPlate;
        Instantiate(platePrefab, spawner.transform.position, Quaternion.identity);
    }


    void Update()
    {
        remainingTime -= Time.deltaTime;
        
        if (remainingTime <= 0)
        {
            Debug.Log("Game over");
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


}
