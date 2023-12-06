using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Fungus;

public class tigerPopUp : MonoBehaviour
{
    public Flowchart flowchart;

    public GameObject tiger;
    public GameObject animalClicked;
    public bool tigerClick;

    // Start is called before the first frame update
    void Start()
    {
        tigerClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        tigerClick = true;
        flowchart.SetBooleanVariable("tigerClick", true);
        Destroy(tiger);
        animalClicked.SetActive(true);
        Debug.Log("Tiger click = " + tigerClick);
    }
}
