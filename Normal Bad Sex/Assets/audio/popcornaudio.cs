using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popcornaudio : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(audioClip, 1);
       
    }
}