using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InsideAreaInfoCardObject : CardObject, IPointerDownHandler, IPointerUpHandler {
    GameObject cardPopUp;

    //클릭 시작시 카드 설명 팝업 띄움
    public void OnPointerDown(PointerEventData eventData) {
        cardPopUp = FactoryManager.GetInstance().CreateInsideAreaInfoCardDescriptionPopup(cardData, transform.parent.transform.parent);
        
        //팝업 위치 조정
        float xPos = transform.localPosition.x + 50f;
        float ypos = transform.localPosition.y + 50f;
        //좌우 스크롤창을 안넘어가게
        if (xPos < 14f) {
            xPos = 14f;
        } else if (xPos > 367f) {
            xPos = 367f;
        }
        cardPopUp.transform.localPosition = new Vector3(xPos, ypos, 0);
    }

    //터치를 떼면 삭제
    public void OnPointerUp(PointerEventData eventData) {
        Destroy(cardPopUp);
    }
}
