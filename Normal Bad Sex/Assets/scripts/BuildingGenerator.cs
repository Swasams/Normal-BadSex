using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject[] windowsVarieties;
    public GameObject[] doorVarieties;
    public GameObject[] windowsillVarieties;
    public Transform[] windowsSpawnPoints; // Array of spawn points for windows
    public Transform[] doorSpawnPoints; // Array of spawn points for doors
    public Transform[] windowsillSpawnPoints; // Array of spawn points for window sills
    public GameObject wallPrefab;
    public Color[] innerColors; // Array of colors for inner elements
    public Color[] outerColors; // Array of colors for outer elements
    public Color[] wallColors;

    private bool hasWindows;
    private bool hasDoor;
    private bool hasWindowsill;
   // private bool useWoodTexture;

    public void RandomizeElements(GameObject mainPrefab)
    {
        //DestroyPreviousElements(mainPrefab);

        hasWindows = true; // Always spawn windows
        hasDoor = true; // Always spawn door
        hasWindowsill = Random.Range(0, 2) == 0; // 50% chance of having a windowsill
        //useWoodTexture = Random.Range(0, 2) == 0; // 50% chance of using wood texture

        GenerateBuilding(mainPrefab);
    }

    void GenerateBuilding(GameObject mainPrefab)
    {
 
            ChangeColors(wallPrefab);
       

        if (hasWindows)
        {
            foreach (Transform spawnPoint in windowsSpawnPoints)
            {
                GameObject windows = InstantiateElement(GetRandomVariety(windowsVarieties), spawnPoint, mainPrefab);
                ChangeColors(windows);
            }
        }

        if (hasDoor)
        {
            foreach (Transform spawnPoint in doorSpawnPoints)
            {
                GameObject door = InstantiateElement(GetRandomVariety(doorVarieties), spawnPoint, mainPrefab);
                ChangeColors(door);
            }
        }

        if (hasWindowsill)
        {
            int numWindowsills = Random.Range(1, 7); // Random number of windowsills between 1 and 6
            for (int i = 0; i < numWindowsills; i++)
            {
                int randomIndex = Random.Range(0, windowsillSpawnPoints.Length);
                GameObject windowsill = InstantiateElement(GetRandomVariety(windowsillVarieties), windowsillSpawnPoints[randomIndex], mainPrefab);
                ChangeColors(windowsill);
            }
        }
    }

    GameObject InstantiateElement(GameObject prefabVariety, Transform spawnPoint, GameObject mainPrefab)
    {
        GameObject newElement = Instantiate(prefabVariety, spawnPoint.position, Quaternion.identity, mainPrefab.transform);
        newElement.transform.SetParent(spawnPoint); // Set the newly instantiated element as a child of the spawn point
        return newElement;
    }

    GameObject GetRandomVariety(GameObject[] varieties)
    {
        int randomIndex = Random.Range(0, varieties.Length);
        return varieties[randomIndex];
    }

    public void ChangeColors(GameObject prefabInstance)
    {
        // Get all child GameObjects of the prefab instance
        Transform[] childTransforms = prefabInstance.GetComponentsInChildren<Transform>(true);

        // Iterate over each child GameObject
        foreach (Transform childTransform in childTransforms)
        {
            // Get the SpriteRenderer component of the child (if it has one)
            SpriteRenderer spriteRenderer = childTransform.GetComponent<SpriteRenderer>();

            // If the child has a SpriteRenderer component, change its color based on the tag of the prefab instance
            if (spriteRenderer != null)
            {
                Color newColor = Color.white;

                // Check for each tag and adjust color accordingly
                if (prefabInstance.CompareTag("Inner"))
                {
                    newColor = innerColors[Random.Range(0, innerColors.Length)];
                }
                else if (prefabInstance.CompareTag("Outer"))
                {
                    newColor = outerColors[Random.Range(0, outerColors.Length)];
                }
                else if (prefabInstance.CompareTag("Wall"))
                {
                    newColor = wallColors[Random.Range(0, wallColors.Length)];
                }

                spriteRenderer.color = newColor;
            }
        }
    }


}


