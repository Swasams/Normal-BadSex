using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public enum StagePosition
    {
        Left,
        Right,
    }

    public static StageManager Instance;


    public Color nonSpeakerFade;
    
    public SpriteRenderer stageLeft;
    public SpriteRenderer stageRight;

    public Character characterLeft;
    public Character characterRight;

    private Vector3 _stageLeftPosition;
    private Vector3 _stageRightPosition;
    
    private List<(SpriteRenderer objectToMove, Vector3 target)> _movementsToExecute;
    
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

        _stageLeftPosition = stageLeft.transform.position;
        _stageRightPosition = stageRight.transform.position;
        _movementsToExecute = new List<(SpriteRenderer, Vector3)>();
    }

    private void Start()
    {
        stageLeft.transform.position = new Vector3( _stageLeftPosition.x - 5 , _stageLeftPosition.y, _stageLeftPosition.z);
        stageRight.transform.position = new Vector3( _stageRightPosition.x + 5 , _stageRightPosition.y, _stageRightPosition.z);
    }

    public void SetSpeakingCharacter(Character character, StagePosition position)
    {
        switch (position)
        {
            case StagePosition.Left:
                if (characterLeft == null)
                {
                    stageLeft.sprite = character.defaultPortrait;
                    stageLeft.gameObject.SetActive(true);
                    _movementsToExecute.Add((stageLeft,_stageLeftPosition));
                }
                
                stageLeft.color = Color.white;
                stageRight.color = nonSpeakerFade;
                
                break;
            case StagePosition.Right:
                if (characterLeft == null)
                {
                    stageRight.sprite = character.defaultPortrait;
                    stageRight.gameObject.SetActive(true);
                    _movementsToExecute.Add((stageRight,_stageRightPosition));
                }
                
                stageRight.color = Color.white;
                stageLeft.color = nonSpeakerFade;
                
                break;
        }
    }

    private void Update()
    {
        if (_movementsToExecute.Count > 0)
        {
            foreach (var movement in _movementsToExecute)
            {
                movement.objectToMove.transform.position = Vector3.Lerp(movement.objectToMove.transform.position,movement.target, 1 * Time.deltaTime);
            }
        }
    }
}
