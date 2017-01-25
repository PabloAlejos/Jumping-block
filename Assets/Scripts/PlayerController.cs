using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public delegate void JumpDelegate();
    public event JumpDelegate jumpEvent;
    public float jumpRate;
    float timeToNextJump = 0;


	// Use this for initialization
	void Start () {
        
       
	}

    public void Jump()
    {
        if (Time.time > timeToNextJump)
        {
            Debug.Log("Jump");
            if (jumpEvent != null)
            {
                jumpEvent();
            }  
        }
        timeToNextJump = Time.time + jumpRate;
    }

    public void TestBlock()
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(myRay, out hit, 2))
        {
            if (GetComponent<Renderer>().material.color != hit.transform.gameObject.GetComponent<Renderer>().material.color)
            {
                Debug.Log("Fail");
            }
        }           
       
    }

    
}
