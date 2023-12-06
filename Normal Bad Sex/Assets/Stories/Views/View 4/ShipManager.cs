using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Collision2D = UnityEngine.Collision2D;

public class ShipManager : MonoBehaviour
{
    public Flowchart flowchart;

    public float speed = 20f;

    // public GameObject tigerShip;
    //public GameObject lionShip;
    public GameObject speechLion;
    public GameObject speechTiger;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        speechLion.SetActive(false);
        speechTiger.SetActive(false);
    }


    void Update()
    {

        //Ship Controls

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || (Input.GetKey(KeyCode.UpArrow)))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || (Input.GetKey(KeyCode.DownArrow)))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || (Input.GetKey(KeyCode.RightArrow)))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow)))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }

    public void OnCollisionEnter2D(Collision2D col)
    { if (col.gameObject.name == "Boat Tiger")
        {
            speechLion.SetActive(true);
            speechTiger.SetActive(true);
            anim.Play("4");
        }
    }

    public void OnCollisionExit2D(Collision2D coll)
    {
        speechLion.SetActive(false);
        speechTiger.SetActive(false);
    }


}

