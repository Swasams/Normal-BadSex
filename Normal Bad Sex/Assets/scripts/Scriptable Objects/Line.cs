using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Line", menuName = "Normal Bad Sex/Line", order = 1)]
public class Line : ScriptableObject
{
    public AudioClip audioFile;
    public string lineText;

    public Character speaker;

    public bool introduceCharacter;
    public string startAnimation;
    public string endAnimation;

    public bool autoAdvanceOnEnd = true;
    public bool wipeAllCharacters = true;
    public int lineNumber;

    public int[] pauseIndexes;
    public float[] pauseTime;
    
    public void ProcessPauses(string literalText)
    {
        List<int> _pauseIndexes = new List<int>();
        List<float> _pauseTime = new List<float>();

        List<int> _effectIndexes = new List<int>();
        
        
        string unfilteredText = literalText;
        string filteredText = "";
        string parsedValue = "";
        bool pauseTimeMatcher = false;

        bool textEffectMatcher = false;
        int matchBeggining = 0;
        foreach (var character in unfilteredText)
        {
            
            //Start matching a pause indicator
            if (!pauseTimeMatcher && !textEffectMatcher && character == '{')
            {
                _pauseIndexes.Add(filteredText.Length);
                pauseTimeMatcher = true;
                continue;
            }
            
            //Stop matching a pause indicator
            if (pauseTimeMatcher && character == '}')
            {
                pauseTimeMatcher = false;
                _pauseTime.Add(float.Parse(parsedValue));
                parsedValue = "";
                continue;
            }

            //Parse a pause indicator value
            if (pauseTimeMatcher)
            {
                if (System.Char.IsDigit(character) || character == '.')
                    parsedValue += character;
                
                continue;
            }

            //Start matching a text effect indicator
            if (!textEffectMatcher && character == '<')
            {
                _effectIndexes.Add(filteredText.Length);
                textEffectMatcher = true;
                continue;
            }
            
            //Stop matching a text effect indicator
            if (textEffectMatcher && character == '>')
            {
                textEffectMatcher = false;
                _effectIndexes.Add(matchBeggining);
                _pauseTime.Add(float.Parse(parsedValue));
                parsedValue = "";
                continue;
            }
            
            //Parse a text effect
            if (textEffectMatcher)
            {
                if (System.Char.IsDigit(character) || character == '.')
                    parsedValue += character;
                
                continue;
            }
            
            filteredText += character;
        }

        lineText = filteredText;
        pauseIndexes = _pauseIndexes.ToArray();
        pauseTime = _pauseTime.ToArray();
    }

}
