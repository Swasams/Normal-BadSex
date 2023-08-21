using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EOGControl : MonoBehaviour
{
    int I;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        I = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (I<13)
        {
            Debug.Log("entering");
            I++;
            return;
        }
        else if (I>=13)
        {
            anim.Play("7");
        }
        
    }
}
