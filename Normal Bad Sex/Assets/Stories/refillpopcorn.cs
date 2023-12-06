using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refillpopcorn : MonoBehaviour
{
    public GameObject[] pop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allInactive = true;

        // Iterate through all objects in the array
        foreach (GameObject obj in pop)
        {
            // Check if the object is active
            if (obj.activeSelf)
            {
                // At least one object is active, so not all objects are inactive
                allInactive = false;
                break;
            }
        }

        if (allInactive)
        {
            foreach (GameObject obj in pop)
            {
                obj.SetActive(true);

            }
        }
    }
   
}
