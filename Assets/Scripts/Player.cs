using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    

    Renderer rend;
    public int lives;
    public Color[] colors;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
    }

    public void SerColor()
    {
        //Hago un raycast y copio el color de la plataforma de debajo
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(myRay, out hit, 100))
            rend.material.color = hit.transform.gameObject.GetComponent<Renderer>().material.color;
    }

    public void Ready()
    {
        FindObjectOfType<UIController>().SetBlocker(false);
    }

}
