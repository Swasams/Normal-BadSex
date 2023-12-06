using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ShowGuy : MonoBehaviour
{
    public Flowchart flowchart;

    public GameObject calling;
    public GameObject guy;
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
        calling.SetActive(false);
        guy.SetActive(true);
        flowchart.SetBooleanVariable("showGuy", true);
    }
}
