using UnityEngine;

public class ClickTracker : MonoBehaviour
{
    // References
    public GameObject objectToEnableOnClick;
    public float timeToEnableObjectFor;
    
    // State
    private float _timeElapsed = 0;
    private bool _shouldBeDisplayed = false;
    void Start()
    {
        EventManager.Instance.Register<MouseClick>(EnableAt);
        objectToEnableOnClick.SetActive(false);
    }

    private void Update()
    {
        if (!_shouldBeDisplayed) return;

        if (_timeElapsed < timeToEnableObjectFor)
        {
            _timeElapsed += Time.deltaTime;
        }
        else
        {
            objectToEnableOnClick.SetActive(false);
            _shouldBeDisplayed = false;
            _timeElapsed = 0;
        }

    }

    void EnableAt(NbsEvent clickEvent)
    {
        transform.position = ((MouseClick)clickEvent).clickPosition; 
        objectToEnableOnClick.SetActive(true);
        _shouldBeDisplayed = true;
    }
}
