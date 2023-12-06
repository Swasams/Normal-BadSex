using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PourController : MonoBehaviour
{
    public Animation glassFillAnim;

    public void Start()
    {

    }

    public void OnCollisionStay2D()
    {
        //Debug.Log("collision detected!");
        GetComponent<Animator>().Play("GlassFill");
 
    }

    public void OnCollisionExit2D()
    {
       // Debug.Log("collision exit");
        //glassFillAnim.enabled = false;
    }
}
