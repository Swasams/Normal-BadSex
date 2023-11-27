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
    

}
