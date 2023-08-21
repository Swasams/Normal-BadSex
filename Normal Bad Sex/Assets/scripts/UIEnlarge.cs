using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnlarge : MonoBehaviour
{
    BoxCollider2D compCol;
    RectTransform uiIransform;
    Vector3 startScale;
    bool scaled = false;
    [SerializeField]float scaleSpeed = 0.1f;


    void Start()
    {
        compCol = GetComponent<BoxCollider2D>();
        uiIransform = GetComponent<RectTransform>();
        startScale = uiIransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (col!=null)
        {
            if (col == compCol && scaled == false)
            {
                scaled = true;
                Vector3 newScale = new Vector3(uiIransform.localScale.x + 1f, uiIransform.localScale.y + 1f, uiIransform.localScale.z);
                LeanTween.scale(gameObject, newScale, scaleSpeed).setEaseInQuad();
            }
        }
        if (col == null && scaled == true)
        {
            scaled = false;
            //Vector3 newScale = new Vector3(uiIransform.localScale.x + 1f, uiIransform.localScale.y + 1f, uiIransform.localScale.z);
            LeanTween.scale(gameObject, startScale, scaleSpeed).setEaseInQuad();
        }
    }
}
