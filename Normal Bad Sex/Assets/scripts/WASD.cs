using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD: MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 1.0f;
    public static WASD instance;
  

    void Start()
    {
        // this.transform.position = new Vector2(11, -16);
    }
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveH, moveV);//OPTIONAL rb.MovePosition();

        Vector2 direction = new Vector2(moveH, moveV);



       
    }

}
