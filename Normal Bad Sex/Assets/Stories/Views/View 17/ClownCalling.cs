using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ClownCalling : MonoBehaviour
{
    public GameObject calling;
    Vector3 point;
    bool clownClick;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        calling.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (col != null)
        {
            if (Input.GetMouseButtonDown(0) && (col.gameObject.tag == "Clown" && clownClick == false))
            {
                clownClick = true;
                calling.SetActive(true);
                Invoke("PlayAnimation", 1f);
            }

        }
    }
    void PlayAnimation()
    {
        anim.Play("17");
    }
    /*
    void OnMouseDown()
    {
        Debug.Log("hyello");
        calling.SetActive(true);
    }
    */
}
