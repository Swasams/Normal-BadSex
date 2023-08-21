using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EOGControlview14 : MonoBehaviour
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

    void OnMouseDown()
    {
        if (I < 14)
        {
            Debug.Log("kill me");
            I++;
            return;
        }
        else if (I >= 14)
        {
            anim.Play("eomg anim");
        }

    }
}
