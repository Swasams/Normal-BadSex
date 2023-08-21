using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ContactsScroll : MonoBehaviour
{
    public float increment = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveItUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveItDown();
        }
    }

    public void MoveItUp()
    {
        //Debug.Log("Key pressed");
        transform.position = new Vector3(transform.position.x,
                                        (transform.position.y - increment),
                                         transform.position.z);
    }

    public void MoveItDown()
    {
        transform.position = new Vector3(transform.position.x,
                                            (transform.position.y + increment),
                                             transform.position.z);
    }
}
