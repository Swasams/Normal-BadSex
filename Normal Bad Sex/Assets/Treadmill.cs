using System;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Treadmill : MonoBehaviour
{
    public NavMeshSurface Surface2D;

    // Global
    public static Treadmill Instance;

    public List<MainStreetSnappingPoint> mainStreetSnappingPoints;

    public Transform mainStreet;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("Should not be another class");
            Destroy(this);
        }
    }

    public void SnapTo(Vector3 position, Vector3 from, Transform detachableObject)
    {
        detachableObject.parent = null;
        Vector3 offset = mainStreet.position - from;
        mainStreet.position = position + offset;
        detachableObject.SetParent(mainStreet);
    }

    private void Start()
    {
        foreach (var mainStrretSnappingPoint in mainStreetSnappingPoints)
        {
            mainStrretSnappingPoint.objectToMove.transform.SetParent(mainStreet);
        }

        EventManager.Instance.Register<SnapEnd>((NbsEvent e) =>
        {
            SnapEnd snapEvent = (SnapEnd)e;
            foreach (var mainStrretSnappingPoint in mainStreetSnappingPoints)
            {
                if (mainStrretSnappingPoint.leftSideEventName.Equals(snapEvent.nameOfPosition))
                {
                    SnapTo(snapEvent.positionToSnapTo, mainStrretSnappingPoint.leftSideSnappingPoint.position, mainStrretSnappingPoint.objectToMove.transform);
                    mainStrretSnappingPoint.SetFacadesRight();
                    break;
                }

                if (mainStrretSnappingPoint.rightSideEventName.Equals(snapEvent.nameOfPosition))
                {
                    SnapTo(snapEvent.positionToSnapTo, mainStrretSnappingPoint.rightSideSnappingPoint.position, mainStrretSnappingPoint.objectToMove.transform);
                    mainStrretSnappingPoint.SetFacadesLeft();
                    break;
                }
            }

            //NavMeshBuilder.UpdateNavMeshDataAsync(Surface2D.navMeshData, GetBuildSettings(), sources, sourcesBounds); 
            Surface2D.UpdateNavMesh(Surface2D.navMeshData);
        });
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Surface2D.UpdateNavMesh(Surface2D.navMeshData);
        }

    }
}
