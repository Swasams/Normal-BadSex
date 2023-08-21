using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Fungus;

public class bearPopUp : MonoBehaviour
{
    public Flowchart flowchart;

    public GameObject bear;
    public GameObject animalClicked;
    public bool bearClick;
  

    // Start is called before the first frame update
    void Start()
    {
        bearClick = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Destroy(bear);
        animalClicked.SetActive(true);
        bearClick = true;
        flowchart.SetBooleanVariable("bearClick", true);
        Debug.Log("Bear Click = " + bearClick);
    }
}