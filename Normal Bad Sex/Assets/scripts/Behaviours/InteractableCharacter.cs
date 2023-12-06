using System;
using UnityEngine;

public class InteractableCharacter : MonoBehaviour
{
    public Character character;
    public Line[] lines;
    public GameObject isActiveObject;
    private Boolean _isActive = false;
    


    private void Start()
    {
        if (!GameManager.Instance.currentStory.linesByCharacters.TryGetValue(character.name , out var linesOfCharacter)) {
           Debug.LogWarning($"Unable to find lines for character {character.name} in the story object {GameManager.Instance.currentStory.name} attached to the Game Manager");
        }else {
            lines = linesOfCharacter.ToArray();
        }
        isActiveObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isActive)
        {
            EventManager.Instance.Fire(new TriggerLines(lines));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) return;
        
        if (_isActive) return;

        _isActive = true;
        isActiveObject.SetActive(true);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) return;
        if (!_isActive) return;
        _isActive = false;
        isActiveObject.SetActive(false);
    }
}
