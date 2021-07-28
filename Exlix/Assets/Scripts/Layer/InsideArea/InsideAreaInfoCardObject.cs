using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InsideAreaInfoCardObject : CardObject, IPointerDownHandler, IPointerUpHandler {
    GameObject cardPopUp;
    //클릭 시작
    public void OnPointerDown(PointerEventData eventData) {
        cardPopUp = FactoryManager.GetInstance().CreateInsideAreaInfoCardDescriptionPopup(CardDAO.SelectCard(1), transform.parent.transform.parent);

        float xPos = transform.position.x - 50f;
        if (xPos < 14f) {
            xPos = 14f;
        } else if (xPos > 367f) {
            xPos = 367f;
        }
        cardPopUp.transform.localPosition = new Vector3(xPos, transform.position.y - 50f, 0);
    }
    //끝
    public void OnPointerUp(PointerEventData eventData) {
        Destroy(cardPopUp);
    }
}
