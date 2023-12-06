using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewtwoend : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator one;
    public Animator two;
    public Animator three;
    public Animator four;
    public Animator five;
    Animator anim;
    private bool animationPlayed = false;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!animationPlayed && one.GetCurrentAnimatorStateInfo(0).IsName("GlassFill") && 
            two.GetCurrentAnimatorStateInfo(0).IsName("GlassFill") && 
            three.GetCurrentAnimatorStateInfo(0).IsName("GlassFill") &&
            four.GetCurrentAnimatorStateInfo(0).IsName("GlassFill") && 
            five.GetCurrentAnimatorStateInfo(0).IsName("GlassFill"))
        {
            anim.Play("2");
            animationPlayed = true;
            //Debug.Log("nicejob");
        }
    }
}
