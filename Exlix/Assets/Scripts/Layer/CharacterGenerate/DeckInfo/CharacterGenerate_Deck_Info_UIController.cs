using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class CharacterGenerate_Deck_Info_UIController : MonoBehaviour, IPointerClickHandler {
    //ī�� ����, ���� ���

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

    public void OnPointerClick(PointerEventData eventData) {//Ŭ���� ��ȣ�ۿ�
        pointer.position = eventData.position;
        SelectObjectByRaycast();
    }

    void UpdateCardDescription(CardDTO card) {//ī�� ����â ������Ʈ
        cardTitle.text = card.Title;
        cardMana.text = card.Mana.ToString();
        cardDescribe.text = card.Explanation;
        cardProperty.text = card.Property;
        cardManaIcon.SetActive(true);
    }

    void SelectObjectByRaycast() {//����ĳ��Ʈ�� ī�� ����
        List<RaycastResult> hitObject = new List<RaycastResult>();
        raycast.Raycast(pointer, hitObject);
        if (hitObject.Count > 0) {
            if (hitObject[0].gameObject.transform.GetComponent<CardObject>()) {
                if (cardObjectOnSelect != null) {
                    cardObjectOnSelect.GetComponent<CardObject>().glowEffect.SetActive(false);
                }

                cardDataOnSelect = hitObject[0].gameObject.transform.GetComponent<CardObject>().cardData;
                cardObjectOnSelect = hitObject[0].gameObject;

                cardObjectOnSelect.GetComponent<CardObject>().glowEffect.SetActive(true);

                UpdateCardDescription(cardDataOnSelect);
            }
        }
    }
}
