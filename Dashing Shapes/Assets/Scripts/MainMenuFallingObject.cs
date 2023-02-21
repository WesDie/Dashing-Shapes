using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFallingObject : MonoBehaviour
{
    RectTransform m_RectTransform;
    Vector2 intPos;

    // Start is called before the first frame update
    void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        intPos = m_RectTransform.anchoredPosition;
        Invoke("Reset", 10);
    }

    void Reset()
    {
        m_RectTransform.anchoredPosition = intPos;
        Invoke("Reset", 10);
    }
}
