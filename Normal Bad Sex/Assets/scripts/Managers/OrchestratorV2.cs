using System;
using UnityEngine;


public class OrchestratorV2 : MonoBehaviour
{
    //References
    public AudioSource dialogSource;

    // State
    private bool _stoppedPlaying;
    private bool _lineSequenceStarted = false;
    private Line _currentLine;
    private Minigame _currentMinigame;
    private bool _waitingForInput;
    private bool _dialogManagerIsWriting;
    private Line[] _currentLines;
    private int _lineCounter;
    private Animator _currentCharacterAnimator;

    private void Start()
    {
        EventManager.Instance.Register<LineEnd>(@event => _dialogManagerIsWriting = false);
        EventManager.Instance.Register<TriggerLines>(e => BeginLines((TriggerLines)e));
    }

    private void BeginLines(TriggerLines triggerLinesEvent)
    {
        //Ignore if a sequence is playing
        if (_lineSequenceStarted) return;

        _lineSequenceStarted = true;
        _currentLines = triggerLinesEvent.lines;
        _currentCharacterAnimator = triggerLinesEvent.characterAnimator;
        _waitingForInput = false;
        _dialogManagerIsWriting = false;
        _stoppedPlaying = true;
        _lineCounter = 0;
    }



    private void Update()
    {

        //Skip line
        if (Input.GetKeyDown(KeyCode.S) && _lineSequenceStarted)
        {
            dialogSource.Stop();
            _stoppedPlaying = true;
            EventManager.Instance.Fire(new LineSkipped());
        }

        if (!_lineSequenceStarted) return;

        if (!ShouldPlayNext()) return;

        PlayNext();

    }



    private void PlayNext()
    {
        if (_currentLines.Length == _lineCounter)
        {
            _lineSequenceStarted = false;
            return;
        }

        _currentLine = _currentLines[_lineCounter];
        if (!_dialogManagerIsWriting)
        {
            dialogSource.PlayOneShot(_currentLine.audioFile);
            _dialogManagerIsWriting = true;
            EventManager.Instance.Fire(new LineStart(_currentLine));

            // We may not have an animator
            if (_currentCharacterAnimator != null)
            {
                try
                {
                    _currentCharacterAnimator.Play(_currentLine.startAnimation);
                }
                catch (Exception e)
                {
                    Debug.LogError("There was an error trying to play an animation: " + e);
                }
            }

        }

        _lineCounter++;
    }


    private bool ShouldPlayNext()
    {
        if (!dialogSource.isPlaying && !WaitingForInput() && !_dialogManagerIsWriting)
        {

            if (_stoppedPlaying)
            {
                return true;
            }

            //Wait two frames for audio clip
            _stoppedPlaying = true;
        }
        else
        {
            _stoppedPlaying = false;
        }

        return false;
    }

    private bool WaitingForInput()
    {
        return _waitingForInput && _currentLine.autoAdvanceOnEnd;
    }
}
