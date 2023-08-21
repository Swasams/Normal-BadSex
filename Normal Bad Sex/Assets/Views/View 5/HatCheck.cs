using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HatCheck : MonoBehaviour
{
    public bool off;
    ShowerManager showermanager;

    // Start is called before the first frame update
    void Start()
    {
        showermanager = ShowerManager.FindInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (off == false && col.gameObject.tag == "clothingcol")
        {
            off = true;
            showermanager.ClothingCount++;
        }
    }
}
