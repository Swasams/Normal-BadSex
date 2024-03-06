using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    void Start()
    {
        EventManager.Instance.Register<MouseClick>(MoveTo);
        _agent = GetComponent<NavMeshAgent>();
        _agent.Warp(transform.position);
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void MoveTo(NbsEvent clickEvent)
    {
        _agent.destination = ((MouseClick)clickEvent).clickPosition; 
    }
}
