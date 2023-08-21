using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlescene : MonoBehaviour
{
    public Animator start;
    public Animator creditanim;
    public GameObject credits;
    public GameObject starter;
    public GameObject title;
    public GameObject frame;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject text;
    public GameObject pod;
    public GameObject creators;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void startbutton()
    {
        Destroy(credits);
        Destroy(pod);
        Destroy(title);
        start.Play("move");
      frame.SetActive(true);
       frame2.SetActive(true);
        frame3.SetActive(true);

    }
    public void creditss()
    {
        Destroy(starter);
        Destroy(pod);
        Destroy(title);
        creditanim.Play("creditplay");
        text.SetActive(true);
    }
    public void restart()
    {
        SceneManager.LoadScene("Menu");
    }
    public void cenza()
    {
        SceneManager.LoadScene("Cenza 5 Min");
        Destroy(frame);
        Destroy(frame2);
        Destroy(frame3);
        Destroy(starter);
        Destroy(pod);
        Destroy(creators);
    }
}
