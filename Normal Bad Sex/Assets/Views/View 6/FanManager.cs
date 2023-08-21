using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FanManager : MonoBehaviour
{
    public bool fanUp;
    public Animator fanAnim;

    // Start is called before the first frame update
    void Start()
    {
        bool fanUp = true;
        fanAnim = GetComponent<Animator>();
       
    }

   // Update is called once per frame
    void Update()
    {
        if (fanUp == false && Input.GetKey("w") || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            //Debug.Log("going up");
            fanAnim.Play("FanUp");
            fanUp = true;
        }

        if (fanUp == true && Input.GetKey("s") || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            //Debug.Log("going down");
            fanAnim.Play("FanDown");
            fanUp = false;
        }
    }
}
