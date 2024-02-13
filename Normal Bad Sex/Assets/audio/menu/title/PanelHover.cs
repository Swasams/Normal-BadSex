using UnityEngine;
using UnityEngine.EventSystems;

public class PanelHover : MonoBehaviour, IPointerEnterHandler
{
    public GameObject prefabToInstantiate;

    private bool isHovered = false;
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    private void Start()
    {
        originalParent = transform.parent;
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0f;
    }

    private void Update()
    {
        if (isHovered && canvasGroup != null)
        {
            // Fade in the panel
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1f, Time.deltaTime * 5f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        // Move the panel to the front within its parent's hierarchy
        transform.SetAsLastSibling();

        // Instantiate the prefab and set it active
        if (prefabToInstantiate != null)
        {
            GameObject instantiatedPrefab = Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
            instantiatedPrefab.transform.SetParent(transform, false);
            CanvasGroup prefabCanvasGroup = instantiatedPrefab.GetComponent<CanvasGroup>();
            if (prefabCanvasGroup == null)
            {
                prefabCanvasGroup = instantiatedPrefab.AddComponent<CanvasGroup>();
            }
            prefabCanvasGroup.alpha = 0f; // Ensure the prefab starts invisible
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        transform.SetParent(originalParent); // Return the panel to its original parent
    }
}
