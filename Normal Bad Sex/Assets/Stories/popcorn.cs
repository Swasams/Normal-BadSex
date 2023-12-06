using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcorn : MonoBehaviour

{ SpriteRenderer  Sprite;
    GameObject GameObject;
    Vector3 position;
    public AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
         position = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioClip, 1);
        Debug.Log("colliding");
        gameObject.SetActive(false);
        transform.position = position;
        
    }
}
