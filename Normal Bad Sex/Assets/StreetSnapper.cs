using System;
using UnityEngine;

public class StreetSnapper : MonoBehaviour
{

    public String positionName;
    public Transform targetSnapPoint;
    private Boolean _isActive = false;


    private void Start()
    {

        EventManager.Instance.Register<SnapEnd>((NbsEvent e) =>
        {
            SnapEnd snapEvent = (SnapEnd) e;
            if (positionName.Equals(snapEvent.nameOfPosition)) return;
            _isActive = false;
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.tag.Equals("Player")) return;
        
        if (_isActive) return;

        _isActive = true;
        EventManager.Instance.Fire(new SnapEnd(targetSnapPoint.position,positionName));

    }
}
