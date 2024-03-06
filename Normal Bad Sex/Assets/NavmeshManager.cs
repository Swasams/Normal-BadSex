using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;

public class NavmeshManager : MonoBehaviour
{
    
    public NavMeshSurface Surface2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Surface2D.BuildNavMeshAsync();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Surface2D.UpdateNavMesh(Surface2D.navMeshData);
        }
        
    }
}
