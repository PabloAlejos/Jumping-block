using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   
    public delegate void PlayerDelegate();
    public event PlayerDelegate jumpEvent;
    public event PlayerDelegate gameOverEvent;
    public float jumpRate;
    public float gravity;
    float timeToNextJump = 0;


    Animator anim;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        gravity = 6f;
       
	}

    public void Jump()
    {
        if (Time.time > timeToNextJump)
        {
            Debug.Log("Jump");
            if (jumpEvent != null)
            {
                anim.SetTrigger("jumpAnim");
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
                gameOverEvent();
                anim.enabled = false;
                StartCoroutine(FallingBlock());
            }
        }           
       
    }


    IEnumerator FallingBlock()
    {
       
        while (transform.position.x > -5f)
        {
            
            transform.Translate(new Vector3(0,-1,0) * gravity * Time.deltaTime);
            yield return null;
        }
        
    }



}
