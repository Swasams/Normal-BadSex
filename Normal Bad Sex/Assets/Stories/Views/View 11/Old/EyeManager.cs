using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class EyeManager : MonoBehaviour
{
    public GameObject eye;
    public Animator eyeAnim;
    public GameObject blowjob;
    public Animator blowjobAnim;
    public bool isCurrentlyColliding;

    public bool bjSeen;

    // Start is called before the first frame update
    void Start()
    {
        eyeAnim = eye.GetComponent<Animator>();
        isCurrentlyColliding = false;
        bjSeen = false;
        blowjobAnim = blowjob.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("BJ Collision: " + isCurrentlyColliding);

        if (Input.GetMouseButtonDown(0) && (isCurrentlyColliding = true) && bjSeen == false)
        {
            //Debug.Log("spacebar and collider");
            bjSeen = true;
            blowjobAnim.enabled = false;
            eyeAnim.Play("EyeOpening");
           

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "CenterCollider")
        {
            isCurrentlyColliding = true;
           // Debug.Log(isCurrentlyColliding);
        }
       
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isCurrentlyColliding = false;
        //Debug.Log(isCurrentlyColliding);
    }



}
