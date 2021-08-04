using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class CharacterGenerate_Deck_Info_UIController : MonoBehaviour, IPointerClickHandler {
    //카드 선택, 설명 기능

    [SerializeField] Canvas canvas = null;

    [SerializeField] Text cardTitle = null;
    [SerializeField] Text cardMana = null;
    [SerializeField] Text cardDescribe = null;
    [SerializeField] Text cardProperty = null;
    [SerializeField] GameObject cardManaIcon = null;

    CardDTO cardDataOnSelect = null;
    GameObject cardObjectOnSelect = null;

    GraphicRaycaster raycast;
    PointerEventData pointer;
    void Start() {
        raycast = canvas.GetComponent<GraphicRaycaster>();
        pointer = new PointerEventData(null);
    }

    public void OnPointerClick(PointerEventData eventData) {//클릭시 상호작용
        pointer.position = eventData.position;
        SelectObjectByRaycast();
    }

    void UpdateCardDescription(CardDTO card) {//카드 설명창 업데이트
        cardTitle.text = card.Title;
        cardMana.text = card.Mana.ToString();
        cardDescribe.text = card.Explanation;
        cardProperty.text = card.Property;
        cardManaIcon.SetActive(true);
    }

    void SelectObjectByRaycast() {//레이캐스트로 카드 선택
        List<RaycastResult> hitObject = new List<RaycastResult>();
        raycast.Raycast(pointer, hitObject);
        if (hitObject.Count > 0) {
            if (hitObject[0].gameObject.transform.GetComponent<CardObject>()) {
                if (cardObjectOnSelect != null) {
                    cardObjectOnSelect.GetComponent<CardObject>().glowEffect.SetActive(false);
                }

                cardDataOnSelect = hitObject[0].gameObject.transform.GetComponent<CardObject>().CardData;
                cardObjectOnSelect = hitObject[0].gameObject;

                cardObjectOnSelect.GetComponent<CardObject>().glowEffect.SetActive(true);

                UpdateCardDescription(cardDataOnSelect);
            }
        }
    }
}
