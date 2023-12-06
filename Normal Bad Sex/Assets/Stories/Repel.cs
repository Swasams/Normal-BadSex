using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel : MonoBehaviour
{
    Vector2 originalPos;
    Collision2D collision;
    

    // Start is called before the first frame update
    void Start()
    {
        
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "lion")
        {
            gameObject.transform.position = originalPos;
        }
    }
}
