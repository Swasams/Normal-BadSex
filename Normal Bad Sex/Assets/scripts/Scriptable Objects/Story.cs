using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Story", menuName = "Normal Bad Sex/Story", order = 2)]
public class Story : ScriptableObject
{
    [SerializeField]
    public List<Line> lines;


    public Dictionary<string, List<Line>> linesByCharacters;


    private int _currentLine;
    private int _currentMinigame;

    public bool IsFinished()
    {
        return _currentLine == lines.Count - 1;
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

    public void SetLines(List<Line> allLines)
    {
        this.lines = allLines;
    }

    public void CreateDictionary()
    {
        Debug.Log("Creating Dictionary");
        linesByCharacters = new Dictionary<string, List<Line>>();
        Debug.Log("Initialized linesByCharacters " + linesByCharacters.Count);
        foreach (var line in lines)
        {
            if (line.speaker == null) continue;
            if (linesByCharacters.TryGetValue(line.speaker.name, out var linesOfCharacter))
            {
                linesOfCharacter.Add(line);
                linesOfCharacter.Sort((line1, line2) => (line1.lineNumber - line2.lineNumber));
            }
            else
            {
                linesOfCharacter = new List<Line> { line };
                linesByCharacters.Add(line.speaker.name, linesOfCharacter);
            }
        }
    }

    // Old minigame code for serialized stories

    // public (Line, Minigame) GetNext()
    // {
    //     int nextLine = _currentLine + 1;
    //     Minigame minigameToReturn = null;
    //     Line lineToReturn = lines[nextLine];
    //
    //     if (minigames.Length > 0)
    //     {
    //         int nextMinigame = _currentMinigame + 1;
    //         minigameToReturn = minigames[nextMinigame].triggerOnLine == nextLine
    //             ? minigames[nextMinigame].minigame
    //             : null;
    //         _currentMinigame = minigameToReturn != null ? nextMinigame : _currentMinigame;
    //     }
    //     _currentLine = nextLine;
    //     return (lineToReturn, minigameToReturn);
    // }


    // public void SetCurrentLine(int lineNumber)
    // {
    //     _currentLine = lineNumber;
    //     if (minigames.Length > 0)
    //     {
    //         int currentMinigameTarget = 0;
    //         while (minigames[currentMinigameTarget].triggerOnLine <= _currentLine)
    //         {
    //             currentMinigameTarget++;
    //         }
    //
    //         _currentMinigame = currentMinigameTarget - 1;
    //     }
    // }

}