using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    // References
    public TextMeshProUGUI textArea;
    public float characterSpeedFactor = 0.1f;
    public GameObject panel;

    // State
    private LineStart _currentLine;
    private LineStart _previousLine; // Unused
    private bool _lineIsFinished = true;
    private bool _lineEndEventFired = true;

    private float _timeBetweenCharacters;
    private float _timeSinceLastCharacter;

    private void Start()
    {
        EventManager.Instance.Register<LineStart>(StartLine);
        EventManager.Instance.Register<LineSkipped>(SkipLine);
        panel.SetActive(false);
    }
    
    private void Update()
    {
        if (_lineEndEventFired) return;
        
        if (!_lineIsFinished && TimeToAdvanceCharacter())
        {
            if (textArea.maxVisibleCharacters < textArea.text.Length)
            {
                textArea.maxVisibleCharacters++;
            }
            else
            {
                _lineIsFinished = true;
            }
        }

        if (!_lineIsFinished) return;
        
        EventManager.Instance.Fire(new LineEnd(_currentLine.line));
        panel.SetActive(false);
        _lineEndEventFired = true;
    }

    private bool TimeToAdvanceCharacter()
    {
        if (_timeSinceLastCharacter > _timeBetweenCharacters)
        {
            _timeSinceLastCharacter = 0;
            return true;
           
        }
        _timeSinceLastCharacter += Time.deltaTime;
        return false;
    }


    private void StartLine(NbsEvent lineStartedEvent)
    {
        _previousLine = _currentLine;
        _currentLine = (LineStart) lineStartedEvent;
        _lineEndEventFired = false;
        _lineIsFinished = false;
        textArea.text = _currentLine.line.lineText;
        textArea.maxVisibleCharacters = 0;
        _timeSinceLastCharacter = 0;
        _timeBetweenCharacters = (_currentLine.line.audioFile.length / _currentLine.line.lineText.Length) * (1 - characterSpeedFactor);
        panel.SetActive(true);
    }
    
    private void SkipLine(NbsEvent e){
        _lineIsFinished = true;
    }

    private void AdvanceLine()
    {
        if (textArea.maxVisibleCharacters < textArea.text.Length)
        {
            _lineIsFinished = false;
        }
        else
        {
            _lineIsFinished = true;
        }
    }
}
