using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject[] windowsVarieties;
    public GameObject[] doorVarieties;
    public GameObject[] windowsillVarieties;
   // public GameObject[] Wall;
   // public Material[] woodTextures;

    private bool hasWindows;
    private bool hasDoor;
    private bool hasWindowsill;
    private bool useWoodTexture;

    public void RandomizeElements(GameObject buildingInstance)
    {
        hasWindows = Random.Range(0, 2) == 0; // 50% chance of having windows
        hasDoor = Random.Range(0, 2) == 0; // 50% chance of having a door
        hasWindowsill = Random.Range(0, 2) == 0; // 50% chance of having a windowsill
        useWoodTexture = Random.Range(0, 2) == 0; // 50% chance of using wood texture

        GenerateBuilding();
    }

    void GenerateBuilding()
    {
        //DestroyPreviousElements();

        if (hasWindows)
        {
            InstantiateElementsAtLocations(windowsVarieties, "WindowLocation");
        }

        
   
           // InstantiateElementsAtLocations(Wall, "WallLocation");
        

        if (hasDoor)
        {
            InstantiateElementsAtLocations(doorVarieties, "DoorLocation");
        }

        if (hasWindowsill)
        {
            InstantiateElementsAtLocations(windowsillVarieties, "WindowsillLocation");
        }

        /*if (useWoodTexture)
        {
            ApplyRandomWoodTexture();
        }*/
    }

    void InstantiateElementsAtLocations(GameObject[] prefabVarieties, string locationTag)
    {
        GameObject[] locations = GameObject.FindGameObjectsWithTag(locationTag);

        foreach (GameObject location in locations)
        {
            int randomIndex = Random.Range(0, prefabVarieties.Length);
            Instantiate(prefabVarieties[randomIndex], location.transform.position, Quaternion.identity, transform);
        }
    }

    /*void ApplyRandomWoodTexture()
    {
        int randomIndex = Random.Range(0, woodTextures.Length);
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            renderer.material = woodTextures[randomIndex];
        }
    }*/

    //void DestroyPreviousElements()
    //{
        // Destroy any existing elements in the building
        //foreach (Transform child in transform)
        //{
           // Destroy(child.gameObject);
        //}
    //}
}
