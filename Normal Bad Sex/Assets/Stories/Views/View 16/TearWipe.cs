using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TearWipe : MonoBehaviour
{
    public float speed = 20f;

    public GameObject tearLeft;
    public Animator fadeTearLeftAnim;

    // Start is called before the first frame update
    void Start()
    {
        fadeTearLeftAnim = tearLeft.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void OnTriggerEnter2D(Collider2D col)
    {
        //fadeTearLeftAnim.Play("FadeAway");
        Debug.Log("Tear hit");
    }
}

