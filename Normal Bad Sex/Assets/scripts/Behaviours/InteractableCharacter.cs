using System;
using UnityEngine;

public class InteractableCharacter : MonoBehaviour
{
    public String characterName;
    public Line[] lines;
    private Boolean _wasTriggered = false;
    
    

    private void Start()
    {
        // Notes for Julian
        
        //Should be ab le to find the Story
        
        // Load the lines corresponding to this character
        
        // Load the assets associated to the character
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        
        if (_wasTriggered) return;

        _wasTriggered = true;
        EventManager.Instance.Fire(new TriggerLines(lines));
    }
    
}
