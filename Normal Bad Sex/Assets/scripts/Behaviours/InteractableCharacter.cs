using System;
using UnityEngine;


public class InteractableCharacter : MonoBehaviour
{
    public Character character;
    public Line[] lines;
    public GameObject isActiveObject;
    private Boolean _isActive = false;

    private Animator _myAnimator;


    private void Start()
    {
        _myAnimator = transform.GetComponent<Animator>();

        if (!GameManager.Instance.currentStory.linesByCharacters.TryGetValue(character.name, out var linesOfCharacter))
        {
            Debug.LogWarning($"Unable to find lines for character {character.name} in the story object {GameManager.Instance.currentStory.name} attached to the Game Manager");
        }
        else
        {
            lines = linesOfCharacter.ToArray();
        }

        if (isActiveObject == null)
        {
            Debug.LogWarning($"Unable to find a  isActiveObject for {character.name} you won't be able to see any icons when iteracting with this character");
        }
        else
        {
            isActiveObject.SetActive(false);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isActive)
        {
            EventManager.Instance.Fire(new TriggerLines(lines, _myAnimator));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) return;

        if (_isActive) return;

        _isActive = true;

        if (isActiveObject != null)
            isActiveObject.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) return;
        if (!_isActive) return;
        _isActive = false;

        if (isActiveObject != null)
            isActiveObject.SetActive(false);
    }
}
