using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Fungus;


public class Unboxing : MonoBehaviour
{
    public Flowchart flowchart;

    public GameObject[] unboxPics;
    public int unboxClicks;
    public bool boxOpen;
    public Animator anim;

    void Start()
    {
        
        unboxClicks = 0;
        boxOpen = false;

        //Set correct in/visibility states so that I don't have to do it manually in the hierarchy each time
        foreach (GameObject pic in unboxPics)
        {
            pic.SetActive(false);
        }
        unboxPics[unboxClicks].SetActive(true);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                foreach (GameObject pic in unboxPics)
                {
                    if (pic.active)
                    {
                        if (hit.collider == pic.GetComponent<Collider2D>() && (unboxClicks < unboxPics.Length - 1))
                        {
                            unboxPics[unboxClicks].SetActive(false);
                            unboxClicks++;
                            unboxPics[unboxClicks].SetActive(true);
                            Debug.Log("Unbox Clicks: " + unboxClicks);
                            
                        }

                        if (unboxClicks == unboxPics.Length-1)
                        {
                            anim.Play("eomg anim");
                            //Debug.Log("box open");
                            boxOpen = true;
                            //flowchart.SetBooleanVariable(boxOpen) = true;
                            flowchart.SetBooleanVariable("boxOpen", true);
                            

                        }
                    }
                }
            }
        }

    }

    public void OnMouseDown()
    {
        //Debug.Log("Clicks: " + unboxClicks);

        //Determine if mouse click is over a collider
      


    }
}
