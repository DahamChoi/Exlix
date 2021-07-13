using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelection : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) {
        // 마우스 혹은 컨트롤러의 포인터로 버튼을 클릭했을 경우.
        Debug.Log(GetComponent<CardObject>().CardData.Explanation);
    }
}
