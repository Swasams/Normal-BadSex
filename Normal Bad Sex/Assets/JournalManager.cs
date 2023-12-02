using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    private List<Line> _linesPlayed;

    private void Start()
    {
        EventManager.Instance.Register<TriggerLines>(AddLines);
        _linesPlayed = new List<Line>();
    }

    private void AddLines(NbsEvent triggerLinesEvent)
    {
        _linesPlayed.AddRange(((TriggerLines) triggerLinesEvent).lines);
    }
}
