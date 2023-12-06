using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collision2D = UnityEngine.Collision2D;
using Fungus;

public class FanGoesDown : MonoBehaviour
{
    
    public Flowchart flowchart;
    public bool fanUp;
    public Animator fanAnim;
    public Animator sunglassesAnim;
    public int fanCount;

    // Start is called before the first frame update
    void Start()
    {
        bool fanUp = true;
        fanAnim = GetComponent<Animator>();
        sunglassesAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if ((fanUp == true) && (col.gameObject.tag == "DownSensor") && (fanCount <6))
        {
            Debug.Log("going down");
            fanAnim.Play("FanDown");
            fanUp = false;
            fanCount++;
        }

        if ((fanUp == true) && (col.gameObject.tag == "DownSensor") && (fanCount == 6))
        {
            Debug.Log("goodbye sunnies");
            sunglassesAnim.Play("FlyingSunglasses");
            fanUp = false;
            fanCount++;
        }


        if ((fanUp == false) && (col.gameObject.tag == "UpSensor"))
        {
            Debug.Log("going up");
            fanAnim.Play("FanUp");
            fanUp = true;
        }
    }
   
}
