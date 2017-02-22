using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{


    Renderer rend;
    Color[] colors;
    public float speed;
    public float stepDistance;
    GameObject player;
    float target;

    //bool sliding = false;

    public float ajuste;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().jumpEvent += Step;
        target = transform.position.z + stepDistance;

        colors = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().colors;
        rend = GetComponent<Renderer>();
        rend.material.color = colors[Random.Range(0, colors.Length)];
    }


    void Step()
    {
        StartCoroutine(PlateStep());
    }


    IEnumerator PlateStep()
    {
       
        while (transform.position.z <= target - ajuste)
        {
            //sliding = true;
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;
        }
        //sliding = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, target);
        target = transform.position.z + stepDistance;

    }

    void FixedUpdate()
    {
        if (transform.position.z > 2)
        {
            player.GetComponent<PlayerController>().jumpEvent -= Step;
            Destroy(gameObject);
        }

    }
}
