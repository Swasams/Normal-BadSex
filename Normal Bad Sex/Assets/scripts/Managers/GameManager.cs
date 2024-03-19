using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Global
    public static GameManager Instance;

    public Story currentStory;

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

        currentStory.CreateDictionary();

        Debug.Log("Current Sotry values: " + currentStory.linesByCharacters.Count);
    }

}
