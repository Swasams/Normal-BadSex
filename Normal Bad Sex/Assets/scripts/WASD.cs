using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float moveSpeed = 5;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;

        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.up * -moveSpeed * Time.deltaTime;

        }
    }
}
