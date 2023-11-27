using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Story", menuName = "Normal Bad Sex/Story", order = 2)]
public class Story : ScriptableObject
{
    public List<Line> lines;

    [System.Serializable]
    public class MinigameEntry
    {
        public Minigame minigame;
        public int triggerOnLine;
    }

    public MinigameEntry[] minigames;


    private int _currentLine;
    private int _currentMinigame;

    public bool IsFinished()
    {
        return _currentLine == lines.Count - 1;
    }

    public (Line, Minigame) GetNext()
    {
        int nextLine = _currentLine + 1;
        Minigame minigameToReturn = null;
        Line lineToReturn = lines[nextLine];

        if (minigames.Length > 0)
        {
            int nextMinigame = _currentMinigame + 1;
            minigameToReturn = minigames[nextMinigame].triggerOnLine == nextLine
                ? minigames[nextMinigame].minigame
                : null;
            _currentMinigame = minigameToReturn != null ? nextMinigame : _currentMinigame;
        }
        _currentLine = nextLine;
        return (lineToReturn, minigameToReturn);
    }

    public void Start()
    {
        _currentLine = -1;
        _currentMinigame = -1;
    }

    public int CurrentLine()
    {
        return _currentLine;
    }

    public void SetCurrentLine(int lineNumber)
    {
        _currentLine = lineNumber;
        if (minigames.Length > 0)
        {
            int currentMinigameTarget = 0;
            while (minigames[currentMinigameTarget].triggerOnLine <= _currentLine)
            {
                currentMinigameTarget++;
            }

            _currentMinigame = currentMinigameTarget - 1;
        }
    }

}