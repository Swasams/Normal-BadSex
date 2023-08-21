using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DisplayNextMouth : MonoBehaviour
{
    /*
     * 
     * 
    public GameObject[] leftSmile;
    public int leftClicks = 0;
    public bool leftFull;

    public GameObject[] rightSmile;
    public int rightClicks;
    public bool rightFull;

    // Start is called before the first frame update
    void Start()
    {
        leftFull = false;
        rightFull = false;

        Debug.Log("Left clicks: " + leftClicks);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (col != null && (col.gameObject.tag == "LeftMouth" && leftFull == false))
            {
                    foreach (GameObject pic in leftSmile)
                    {
                        if (leftClicks < 3)
                        {
                            leftSmile[leftClicks].SetActive(false);
                            leftClicks++;
                            Debug.Log("Left clicks: " + leftClicks);
                            leftSmile[leftClicks].SetActive(true);

                        }


                        if (Input.GetMouseButtonDown(0) && (col.gameObject.tag == "RightMouth" && rightFull == false))
                        {
                                if (rightClicks < 3)
                            {
                                rightSmile[rightClicks].SetActive(false);
                                rightClicks++;
                                Debug.Log("Right clicks: " + rightClicks);
                                rightSmile[rightClicks].SetActive(true);

                            }

                    }
                    }
                
            }

        }

    }
    *
    *
    */

}
    
