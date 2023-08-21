using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HandleRotation : MonoBehaviour
{

       //Counting Rotations
    /* private float totalRotation = 0;
    public int nrOfRotations; */

    /*
    {
        get
        {
            return ((int)totalRotation) / 360;
        }
    }
    
    private Vector3 lastPoint;
      */

    //Lorg's Code
    Quaternion originalRotation;
    float startAngle;
    Collider2D colHandle;
 

    public void Start()
    {
        
        //Counting Rotations
        /* lastPoint = transform.TransformDirection(Vector3.forward);
        lastPoint.z = 0; */

        //Lorg's code
        originalRotation = this.transform.rotation;
        colHandle = GetComponent<CircleCollider2D>();
        

    }

    void Update()
    {


        //Lorg's Code
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (col!=null && col == colHandle)
            {
                InputIsDown();
              
            }
        }
        if (Input.GetMouseButton(0))
        {
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (col!=null && col == colHandle)
            {
                InputIsHeld();
              
            }
        }

       


        //Counting Rotations
        /*
          Vector3 facing = transform.TransformDirection(Vector3.forward);
          facing.z = 0;

          float angle = Vector3.Angle(lastPoint, facing);
          if (Vector3.Cross(lastPoint, facing).z < 0)
              angle *= -1;

          totalRotation += angle;
          lastPoint = facing;

          //All the debugs

          /*
          Debug.Log("Facing: " + facing);
          Debug.Log("Angle: " + angle);
          Debug.Log("Total Rotation: " + totalRotation);
          Debug.Log("Number: " + nrOfRotations);
          */

    }

    public void InputIsDown()
    {     
        originalRotation = this.transform.rotation;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 vector = Input.mousePosition - screenPos;
        startAngle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }
    
    public void InputIsHeld()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position); //screen position mouse
        Vector3 vector = Input.mousePosition - screenPos; //vector from camera to mouse position
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;  
        Quaternion newRotation = Quaternion.AngleAxis(angle - startAngle , this.transform.forward);
        newRotation.y = 0; //see comment from above 
        newRotation.eulerAngles = new Vector3(0,0,newRotation.eulerAngles.z);
        this.transform.rotation = originalRotation *  newRotation;
    }
}