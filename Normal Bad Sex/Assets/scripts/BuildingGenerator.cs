using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject[] windowsVarieties;
    public GameObject[] doorVarieties;
    public GameObject[] windowsillVarieties;
    public GameObject[] curtainVarieties;
    public Transform[] windowsSpawnPoints; // Array of spawn points for windows
    public Transform[] doorSpawnPoints; // Array of spawn points for doors
    public Transform[] windowsillSpawnPoints;
    public Transform[] CurtainSpawnPoints;// Array of spawn points for window sills
    public GameObject wallPrefab;
    public Color[] innerColors; // Array of colors for inner elements
    public Color[] outerColors; // Array of colors for outer elements
    public Color[] wallColors;

    private bool hasWindows;
    private bool hasCurtains;
    private bool hasDoor;
    private bool hasWindowsill;
    // private bool useWoodTexture;

    public void RandomizeElements(GameObject mainPrefab)
    {
        //DestroyPreviousElements(mainPrefab);

        hasWindows = true; // Always spawn windows
        hasDoor = true; // Always spawn door
        hasWindowsill = true;
        hasCurtains = true;// 50% chance of having a windowsill
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
        if (hasCurtains)
        {
            int numCurtains = Random.Range(1, 10); // Random number of curtains between 1 and 9
            for (int i = 0; i < numCurtains; i++)
            {
                int randomIndex = Random.Range(0, windowsillSpawnPoints.Length);
                GameObject curtain = InstantiateElement(GetRandomVariety(curtainVarieties), CurtainSpawnPoints[randomIndex], mainPrefab);
                ChangeColors(curtain);
            }
        }
    }

    GameObject InstantiateElement(GameObject prefabVariety, Transform spawnPoint, GameObject mainPrefab)
    {
        // Instantiate the prefabVariety at the spawnPoint position with the same rotation as the mainPrefab
        GameObject newElement = Instantiate(prefabVariety, spawnPoint.position, mainPrefab.transform.rotation);

        // Set the newly instantiated element as a child of the spawnPoint
        newElement.transform.SetParent(spawnPoint);

        return newElement;
    }


    GameObject GetRandomVariety(GameObject[] varieties)
    {
        int randomIndex = Random.Range(0, varieties.Length);
        return varieties[randomIndex];
    }
    public void ChangeColorsRecursively(GameObject gameObject)
    {
        // Create a HashSet to store visited GameObjects
        HashSet<GameObject> visited = new HashSet<GameObject>();

        // Call the helper method to recursively change colors
        ChangeColorsRecursivelyHelper(gameObject.transform, visited);
    }

    private void ChangeColorsRecursivelyHelper(Transform transform, HashSet<GameObject> visited)
    {
        // Get the GameObject associated with the current Transform
        GameObject gameObject = transform.gameObject;

        // If the GameObject has been visited before, return to avoid infinite loops
        if (visited.Contains(gameObject))
        {
            return;
        }

        // Mark the current GameObject as visited
        visited.Add(gameObject);

        // Get the SpriteRenderer component of the GameObject
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // If the GameObject has a SpriteRenderer component, change its color based on its parent's tag
        if (spriteRenderer != null)
        {
            Color newColor = Color.white;

            if (gameObject.CompareTag("Inner"))
            {
                newColor = innerColors[Random.Range(0, innerColors.Length)];
            }
            else if (gameObject.CompareTag("Outer"))
            {
                newColor = outerColors[Random.Range(0, outerColors.Length)];
            }
            else if (gameObject.CompareTag("Wall"))
            {
                newColor = wallColors[Random.Range(0, wallColors.Length)];
            }

            spriteRenderer.color = newColor;
        }

        // Recursively call this method for each child Transform
        foreach (Transform childTransform in transform)
        {
            ChangeColorsRecursivelyHelper(childTransform, visited);
        }
    }


public void ChangeColors(GameObject prefabInstance)
    {
        // Create a queue to store the child objects to be processed
        Queue<Transform> queue = new Queue<Transform>();

        // Enqueue the root object
        queue.Enqueue(prefabInstance.transform);

        // Iterate over the queue until it's empty
        while (queue.Count > 0)
        {
            // Dequeue the next object
            Transform currentTransform = queue.Dequeue();

            // Get the SpriteRenderer component of the current object (if it has one)
            SpriteRenderer spriteRenderer = currentTransform.GetComponent<SpriteRenderer>();

            // If the current object has a SpriteRenderer component, change its color based on the tag of the prefab instance
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

            // Enqueue all child objects for further processing
            foreach (Transform childTransform in currentTransform)
            {
                queue.Enqueue(childTransform);
            }
        }
    }
}
    
