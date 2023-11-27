using UnityEngine;

public class OrchestratorV2 : MonoBehaviour
{
    //References
    public AudioSource dialogSource;
    

    
    //Properties
    public int lastLineOverride;
    public bool overrideLine;
    
    // State
    private bool _stoppedPlaying;
    private bool _storyStarted = false;
    private Line _currentLine;
    private Minigame _currentMinigame;
    private bool _waitingForInput;
    private bool _dialogManagerIsWriting;
    private Line[] _currentLines;
    private int _lineCounter;
    
    private void Start()
    {
        EventManager.Instance.Register<LineEnd>(@event => _dialogManagerIsWriting = false);
        EventManager.Instance.Register<TriggerLines>(e => BeginLines(((TriggerLines) e).lines));
    }

    private void BeginLines(Line[] lines)
    {
        if (_storyStarted) return;
        _currentLines = lines;
        _storyStarted = true;
        _waitingForInput = false;
        _dialogManagerIsWriting = false;
        _stoppedPlaying = true;
        _lineCounter = 0;
    }
    
    

    private void Update()
    {
        if (!_storyStarted) return;
        
        if (!ShouldPlayNext()) return;

        PlayNext();

    }

    private void PlayNext()
    {
        
        _currentLine = _currentLines[_lineCounter];
        _lineCounter++;
        if (_currentLines.Length == _lineCounter)
        {
            _storyStarted = false;
        }

        if (!_dialogManagerIsWriting)
        {
            dialogSource.PlayOneShot(_currentLine.audioFile);
            _dialogManagerIsWriting = true;
            EventManager.Instance.Fire(new LineStart(_currentLine));
        }
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
