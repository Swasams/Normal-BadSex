using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{ private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        Debug.Log("Flame");
        anim.Play("BurritoFlame"); ;
    }
}

