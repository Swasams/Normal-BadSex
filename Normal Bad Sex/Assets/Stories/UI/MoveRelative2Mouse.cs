using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class MoveRelative2Mouse : MonoBehaviour
{

    public Vector3 pz;
    public Vector3 myOffset = new Vector3(-2.47f, -2.47f, 0f);
    public float moveModifier;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myOrigin = Camera.main.transform.position;
        //Debug.DrawRay(myOrigin, Vector3.left, Color.green, 60f);
        //Debug.DrawRay(myOrigin, Vector3.up, Color.red, 60f);

        Vector3 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //pz = Camera.main.transform.TransformPoint(pz);
        pz.z = 0;
        gameObject.transform.position = pz;
        //Debug.Log("Mouse Position: " + pz);

        transform.position = new Vector3(myOrigin.x + (pz.x * moveModifier), myOrigin.y + (pz.y * moveModifier), 0);
        transform.position += myOffset;
       // Debug.DrawRay(pz, transform.position, Color.magenta, .2f);
        //move based on the starting position and its modified value.
    }
   
}

