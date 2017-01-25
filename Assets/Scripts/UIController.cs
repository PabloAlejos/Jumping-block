using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameController gc; 
    public Color[] colors;
    
    public Text time;

    void Update()
    {
        time.text = gc.remainingTime.ToString("00.00");
    }

    public void SetPlayerColor(int newColor)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = colors[newColor];
    }
}
