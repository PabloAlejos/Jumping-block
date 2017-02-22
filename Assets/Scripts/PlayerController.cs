using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public delegate void PlayerDelegate(float value);
    public delegate void PlayerJumpDelegate();
    public event PlayerJumpDelegate jumpEvent;
    public event PlayerDelegate failEvent;
    public event PlayerDelegate successEvent;
    public float jumpRate;
    public float gravity;
    public bool allowDestroy;


    float timeToNextJump = 0;


    Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        gravity = 6f;
    }

    public bool Jump()
    {
        if (Time.time > timeToNextJump)
        {
            Debug.Log("Jump");
            if (jumpEvent != null)
            {
                anim.SetTrigger("jumpAnim");
                jumpEvent();
            }
            timeToNextJump = Time.time + jumpRate;
           return true;
        }
       return false;
    }

    public void TestBlock()
    {
        RaycastHit hit;
        Ray myRay = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(myRay, out hit, 2))
        {

            if (GetComponent<Renderer>().material.color != hit.transform.gameObject.GetComponent<Renderer>().material.color)
            {
                failEvent(2f);
           
                Handheld.Vibrate();

            }
            else
            {
                successEvent(1f);
            }

        }

    }


    IEnumerator FallingBlock()
    {
        while (transform.position.x > -5f)
        {
            transform.Translate(new Vector3(0, 0, -1) * gravity * Time.deltaTime);
            yield return null;
        }
    }

    public void ResetPos()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }


}
