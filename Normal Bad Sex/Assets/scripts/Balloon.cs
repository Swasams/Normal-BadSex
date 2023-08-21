using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Animator balloon;

    public string colour;
    void Start()
    {
        balloon = gameObject.GetComponent<Animator>();

    }
    void Update()
    {
    }

    void OnMouseOver()
    {
        Debug.Log("entering");
        if (colour == "blue ") ;
        {

            if (Input.GetMouseButtonDown(0))
            {
                balloon.Play("Balloon");
            }

        }
        if (colour== "red") ;
        {

            if (Input.GetMouseButton(0))
            {
                balloon.Play("redB");
            }
        }
        if (colour == "green") ;
        {

            if (Input.GetMouseButtonDown(0))
            {
                balloon.Play("greenB");
            }
        }
        if (gameObject.tag == "Lgreen") ;
        {

            if (Input.GetMouseButtonDown(0))
            {
                balloon.Play("LgreenB");
            }
        }
        if (gameObject.tag == "yellow") ;
        {

            if (Input.GetMouseButtonDown(0))
            {
                balloon.Play("yellowB");
            }
        }
    }
}
