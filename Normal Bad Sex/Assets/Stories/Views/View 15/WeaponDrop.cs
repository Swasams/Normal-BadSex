using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class WeaponDrop : MonoBehaviour
{
    public GameObject thisWeapon;
    public float moveSpeed;
    public Vector2 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

       //transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.time);

        //new Vector2(moveSpeed * Time.deltaTime, targetPosition);
    }

    public void DropIt()
    {
        /*
        this.gameObject.GetComponent<Animator>().speed = 0;

        LeanTween.moveY(thisWeapon, transform.position.y - 00000f, moveSpeed);
        
        LeanTween.scale(thisWeapon, new Vector2(0,0), moveSpeed);
        Debug.Log("heyo drop it script");
        */
    }

}
