using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStreetSnappingPoint : MonoBehaviour
{
    public string rightSideEventName;
    public Transform rightSideSnappingPoint;
    public string leftSideEventName;
    public Transform leftSideSnappingPoint;
    public GameObject rightSideFacade;
    public GameObject leftSideFacade;

    public void SetFacadesLeft()
    {
        rightSideFacade.SetActive(false);
        leftSideFacade.SetActive(true);
    }
    
    public void SetFacadesRight()
    {
        rightSideFacade.SetActive(true);
        leftSideFacade.SetActive(false);
    }
    
}
