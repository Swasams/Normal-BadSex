using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BuildingGenerator))]
public class CustomBuilding : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BuildingGenerator buildingGenerator = (BuildingGenerator)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Randomize Elements"))
        {
            // Find the parent GameObject of the BuildingGenerator instance
            GameObject buildingInstance = ((Component)target).gameObject;

            // Call the RandomizeElements method on the specific instance with the GameObject argument
            buildingGenerator.RandomizeElements(buildingInstance);
        }
    }
}
