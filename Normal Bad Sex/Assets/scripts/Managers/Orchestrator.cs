using UnityEngine;

public class Orchestrator : MonoBehaviour
{
    //References
    public Story currentStory;
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
    
    private void Start()
    {
        // if (Application.isEditor)
        // {
        //     if (overrideLine)
        //     {
        //         currentStory.SetCurrentLine(lastLineOverride);
        //     }
        // } 
        
        EventManager.Instance.Register<LineEnd>(@event => _dialogManagerIsWriting = false);
    }

    private void BeginStory()
    {
        if (_storyStarted) return;
        currentStory.Start();
        _storyStarted = true;
        _waitingForInput = false;
        _dialogManagerIsWriting = false;
        _stoppedPlaying = true;
    }
    
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) BeginStory();
        
        if (currentStory.IsFinished() || !_storyStarted) return;
        
        if (!ShouldPlayNext()) return;

        PlayNext();

    }

    private void PlayNext()
    {
        //(_currentLine, _currentMinigame) = currentStory.GetNext();
        _currentMinigame?.Start();
        if (!_dialogManagerIsWriting)
        {
            dialogSource.PlayOneShot(_currentLine.audioFile);
            _dialogManagerIsWriting = true;
            EventManager.Instance.Fire(new LineStart(_currentLine));
            if (_currentLine.speaker.name == "Lion")
            {
                StageManager.Instance.SetSpeakingCharacter(_currentLine.speaker,StageManager.StagePosition.Right);

            }
            else
            {
                StageManager.Instance.SetSpeakingCharacter(_currentLine.speaker,StageManager.StagePosition.Left);
            }
        }
        else
        {
            Debug.LogWarning($"Got a null line when executing line number { currentStory.CurrentLine() }");
        }
    }


    private bool ShouldPlayNext()
    {
        bool minigameCompleted = _currentMinigame?.IsCompleted() ?? true;
        if (!dialogSource.isPlaying && !WaitingForInput() && !_dialogManagerIsWriting && minigameCompleted)
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
