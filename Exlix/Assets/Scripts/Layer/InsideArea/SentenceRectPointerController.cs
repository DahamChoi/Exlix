using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SentenceRectPointerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {
    [SerializeField] ScrollRect scrollRect = null;
    public bool isSkiped = false;
    bool isClicked = false;
    public void OnPointerClick(PointerEventData eventData) {
        isSkiped = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isClicked = false;
    }

    public void UpdateScroll() {
        if (isClicked) return;
        scrollRect.verticalNormalizedPosition = 0.0f;
    }
}
