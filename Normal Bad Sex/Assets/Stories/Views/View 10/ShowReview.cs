using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class ShowReview : MonoBehaviour
{
    public GameObject emptyReview;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("clicked");
        Destroy(emptyReview);
        anim.Play("10");
      
    }
}
