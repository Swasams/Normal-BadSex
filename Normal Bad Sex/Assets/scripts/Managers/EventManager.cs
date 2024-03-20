using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    // Global
    public static EventManager Instance;

    // Properties
    public bool logEventFires = true;

    // State
    private readonly Dictionary<Type, NbsEvent.Handler> _registeredHandlers = new Dictionary<Type, NbsEvent.Handler>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("Should not be another class");
            Destroy(this);
        }
    }

    public void Register<T>(NbsEvent.Handler handler) where T : NbsEvent
    {
        var type = typeof(T);
        if (_registeredHandlers.ContainsKey(type))
        {
            if (!IsEventHandlerRegistered(type, handler))
                _registeredHandlers[type] += handler;
        }
        else
        {
            _registeredHandlers.Add(type, handler);
        }
    }

    public void Unregister<T>(NbsEvent.Handler handler) where T : NbsEvent
    {
        var type = typeof(T);
        if (!_registeredHandlers.TryGetValue(type, out var handlers)) return;

        handlers -= handler;

        if (handlers == null)
        {
            _registeredHandlers.Remove(type);
        }
        else
        {
            _registeredHandlers[type] = handlers;
        }
    }

    public void Fire(NbsEvent e)
    {
        var type = e.GetType();
        if (logEventFires) Debug.Log($"<color=green>Event Manager Fire {e.GetType()}</color>");
        if (_registeredHandlers.TryGetValue(type, out var handlers))
        {
            handlers(e);
        }
    }

    private bool IsEventHandlerRegistered(Type typeIn, Delegate prospectiveHandler)
    {
        return _registeredHandlers[typeIn].GetInvocationList()
            .Any(existingHandler => existingHandler == prospectiveHandler);
    }
}

public abstract class NbsEvent
{
    public delegate void Handler(NbsEvent e);
}

// Meta Game State Event
public class GameStarted : NbsEvent
{
}

public class StoryStarted : NbsEvent
{
}

public class LineStart : NbsEvent
{

    public readonly Line line;

    public LineStart(Line line)
    {
        this.line = line;
    }
}

public class LineEnd : NbsEvent
{
    public readonly Line line;

    public LineEnd(Line line)
    {
        this.line = line;
    }
}

public class LineSkipped : NbsEvent
{
    public LineSkipped()
    {
    }
}

public class TriggerLines : NbsEvent
{
    public readonly Line[] lines;
    public readonly Animator characterAnimator;

    public TriggerLines(Line[] lines, Animator characterAnimator)
    {
        this.lines = lines;
        this.characterAnimator = characterAnimator;
    }
}

public class MouseClick : NbsEvent
{
    public readonly Vector3 clickPosition;

    public MouseClick(Vector3 clickPosition)
    {
        this.clickPosition = clickPosition;
    }
}

public class SnapEnd : NbsEvent
{
    public readonly Vector3 positionToSnapTo;
    public readonly String nameOfPosition;

    public SnapEnd(Vector3 positionToSnapTo, String nameOfPosition)
    {
        this.positionToSnapTo = positionToSnapTo;
        this.nameOfPosition = nameOfPosition;
    }
}

public class MinigameStarted : NbsEvent
{
}

public class MinigameEnded : NbsEvent
{
}

