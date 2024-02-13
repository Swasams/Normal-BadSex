using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIEnlarge1: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform targetPanel;
    public float expandSize = 0.7f;
    public float slideSpeed = 5f;
    public bool slideToLeft = false; // Whether to slide the panel to the left or right

    private Vector2 originalSize;
    private Vector2 targetSize;
    private Vector2 targetPosition;

    private bool isHovered = false;

    private void Start()
    {
        originalSize = targetPanel.sizeDelta;
        targetSize = originalSize * expandSize;
        targetPosition = targetPanel.anchoredPosition;
    }

    private void Update()
    {
        if (isHovered)
        {
            // Smoothly expand the panel size
            targetPanel.sizeDelta = Vector2.Lerp(targetPanel.sizeDelta, targetSize, Time.deltaTime * slideSpeed);
            // Move the panel to the left or right based on the public value
            float direction = slideToLeft ? -1f : 1f;
            targetPanel.anchoredPosition = Vector2.Lerp(targetPanel.anchoredPosition, Vector2.right * direction * Screen.width / 3f, Time.deltaTime * slideSpeed);
        }
        else
        {
            // Reset the panel size and position when not hovered
            targetPanel.sizeDelta = Vector2.Lerp(targetPanel.sizeDelta, originalSize, Time.deltaTime * slideSpeed);
            targetPanel.anchoredPosition = Vector2.Lerp(targetPanel.anchoredPosition, targetPosition, Time.deltaTime * slideSpeed);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}