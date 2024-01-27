using UnityEngine;

public class PointerController : MonoBehaviour
{
    private Camera _cam;

    private Vector3 _mousePosition;
    private LayerMask _mask;

    void Start()
    {
        _cam = Camera.main;
        _mask = LayerMask.GetMask("Walkable");
    }
    
    private void Update()
    {
        _mousePosition = Input.mousePosition;

        transform.position = _mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(_mousePosition);
            RaycastHit hit;

            Vector3 screenToWorld = _cam.ScreenToWorldPoint(_mousePosition);

            if (Physics.Raycast(ray, out hit,1000,_mask))
            {
                Debug.DrawLine(screenToWorld,hit.point,Color.red,5);
                EventManager.Instance.Fire( new MouseClick(hit.point));
            }
            
        }
    }
}
