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

    public Transform[] windowsSpawnPoints; // Array of spawn points for windows
    public Transform[] doorSpawnPoints; // Array of spawn points for doors
    public Transform[] windowsillSpawnPoints; // Array of spawn points for window sills

    public Color[] colors; // Array of colors for randomization

    private bool hasWindows;
    private bool hasDoor;
    private bool hasWindowsill;
    private bool useWoodTexture;

    public void RandomizeElements(GameObject mainPrefab)
    {
        hasWindows = Random.Range(0, 2) == 0; // 50% chance of having windows
        hasDoor = Random.Range(0, 2) == 0; // 50% chance of having a door
        hasWindowsill = Random.Range(0, 2) == 0; // 50% chance of having a windowsill
        useWoodTexture = Random.Range(0, 2) == 0; // 50% chance of using wood texture

        GenerateBuilding(mainPrefab);
    }

    void GenerateBuilding(GameObject mainPrefab)
    {
        //DestroyPreviousElements(); // Uncomment this if needed

        if (hasWindows)
        {
            int randomIndex = Random.Range(0, windowsSpawnPoints.Length);
            GameObject windows = InstantiateElement(windowsVarieties, windowsSpawnPoints[randomIndex], mainPrefab);
            ChangeColors(windows);
        }

        if (hasDoor)
        {
            int randomIndex = Random.Range(0, doorSpawnPoints.Length);
            GameObject door = InstantiateElement(doorVarieties, doorSpawnPoints[randomIndex], mainPrefab);
            ChangeColors(door);
        }

        if (hasWindowsill)
        {
            int randomIndex = Random.Range(0, windowsillSpawnPoints.Length);
            GameObject windowsill = InstantiateElement(windowsillVarieties, windowsillSpawnPoints[randomIndex], mainPrefab);
            ChangeColors(windowsill);
        }

        /*if (useWoodTexture)
        {
            ApplyRandomWoodTexture();
        }*/
    }

    GameObject InstantiateElement(GameObject[] prefabVarieties, Transform spawnPoint, GameObject mainPrefab)
    {
        int randomIndex = Random.Range(0, prefabVarieties.Length);
        GameObject newElement = Instantiate(prefabVarieties[randomIndex], spawnPoint.position, Quaternion.identity, mainPrefab.transform);
        newElement.transform.SetParent(spawnPoint); // Set the newly instantiated element as a child of the spawn point
        return newElement;
    }

    void ChangeColors(GameObject prefabInstance)
    {
        Renderer[] renderers = prefabInstance.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.sharedMaterials;

            foreach (Material material in materials)
            {
                material.color = colors[Random.Range(0, colors.Length)];
            }
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
