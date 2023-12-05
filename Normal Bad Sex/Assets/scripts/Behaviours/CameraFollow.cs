using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 _distanceOffset;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 player2D = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 camera2D = new Vector2(transform.position.x, transform.position.z);
        Vector2 distanceOffset2D = player2D - camera2D;
        _distanceOffset = new Vector3(distanceOffset2D.x, 0, distanceOffset2D.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionTarget = player.transform.position - _distanceOffset;
        transform.position = new Vector3(positionTarget.x,transform.position.y,positionTarget.z);
    }
}
