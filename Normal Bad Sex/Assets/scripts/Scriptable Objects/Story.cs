using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Story", menuName = "Normal Bad Sex/Story", order = 2)]
public class Story : ScriptableObject
{
    public List<Line> lines;

    [System.Serializable]
    public class CharacterEntry
    {
        public string characterName;
        public List<Line> lines;

        public CharacterEntry(string characterName, List<Line> lines)
        {
            this.characterName = characterName;
            this.lines = lines;
        }
    }

    public List<CharacterEntry> linesByCharacters;


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

    public void SetLines(Dictionary<string, List<Line>> linesPerCharacter,List<Line> allLines )
    {
        this.lines = allLines;
        this.linesByCharacters = new List<CharacterEntry>();
        foreach (var (character,lines) in linesPerCharacter)
        {
            linesByCharacters.Add(new CharacterEntry(character,lines));
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