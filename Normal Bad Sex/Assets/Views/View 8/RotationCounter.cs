using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using Debug = UnityEngine.Debug;
using Collision2D = UnityEngine.Collision2D;

public class RotationCounter : MonoBehaviour
{
    public Flowchart flowchart;

    public GameObject ColliderA;
    public GameObject ColliderB;
    //public GameObject rotationStick;

    public bool colliderAHit;
    public bool colliderBHit;

    private int rotationCount;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(this.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (colliderAHit == true && colliderBHit == true)
        {
            rotationCount++;

            flowchart.SetIntegerVariable("rotationCount", rotationCount);

            Debug.Log("Rotations: " + rotationCount);
            colliderAHit = false;
            colliderBHit = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collided with : " + collision.gameObject.name);
       // Debug.Log("collided with something");
        if (collision.gameObject.name == "ColliderA")
        {
            colliderAHit = true;
            //Debug.Log("Col A hit");
        }

        if (collision.gameObject.name == "ColliderB")
        {
            colliderBHit = true;
           // Debug.Log("Col B hit");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("collided with : " + other.gameObject.name);
        //Debug.Log("collided with something");
        if (other.gameObject.name == "ColliderA")
        {
            colliderAHit = true;
            //Debug.Log("Col A hit");
        }

        if (other.gameObject.name == "ColliderB")
        {
            colliderBHit = true;
            //Debug.Log("Col B hit");
        }
    }
}
