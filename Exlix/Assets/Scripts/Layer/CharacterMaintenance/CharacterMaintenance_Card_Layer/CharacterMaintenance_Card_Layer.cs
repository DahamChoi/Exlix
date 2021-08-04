using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CharacterMaintenance_Card_Layer : MonoBehaviour, IPointerClickHandler {

    [SerializeField] GameObject deckListArea = null;
    [SerializeField] Canvas targetCanvas = null;

    //버튼
    [SerializeField] Button discardButton = null;

    //카드 설명창
    [SerializeField] Text cardTitle = null;
    [SerializeField] Text cardMana = null;
    [SerializeField] Text cardDescribe = null;
    [SerializeField] Text cardProperty = null;
    [SerializeField] GameObject cardManaIcon = null;

    //raycast 변수
    GraphicRaycaster raycast = null;
    PointerEventData pointer = null;

    CardDTO cardDataOnSelect = null;
    GameObject cardObjectOnSelect = null;
    CharacterInfoDTO characterInfo = null;


    void Start() {
        ButtonInit();
    }
    private void OnEnable() {
        Init();
        UpdateDeckList();
    }

    void Init() {
        raycast = targetCanvas.GetComponent<GraphicRaycaster>();
        pointer = new PointerEventData(null);
        characterInfo = CharacterInfoDAO.GetCharacterInfo();
    }

    void ButtonInit() {
        discardButton.onClick.AddListener(() => {
            DiscardCardFromDeck();
        });
    }

    public void OnPointerClick(PointerEventData eventData) {
        pointer.position = eventData.position;
        SelectObjectByRaycast();
    }

    void UpdateDeckList() {
        Transform[] childList = deckListArea.GetComponentsInChildren<Transform>(true);//기존 레이어에 존재하던 자식들 삭제
        if (childList != null) {
            for (int i = 1; i < childList.Length; i++) {
                if (childList[i] != transform) Destroy(childList[i].gameObject);
            }
        }

        for (int i = 0; i < characterInfo.CardList.Count; i++) {
            GameObject obj = FactoryManager.GetInstance().CreateCardObject(characterInfo.CardList[i], deckListArea.transform);
            obj.name = $"card_{i}";
        }
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
    void UpdateCardDescription(CardDTO card) {
        cardTitle.text = card.Title;
        cardMana.text = card.Mana.ToString();
        cardDescribe.text = card.Explanation;
        cardProperty.text = card.Property;
        cardManaIcon.SetActive(true);
    }

    void DeleteCardDescription() {
        cardTitle.text = "";
        cardMana.text = "";
        cardDescribe.text = "";
        cardProperty.text = "";
        cardManaIcon.SetActive(false);
    }

    void DiscardCardFromDeck() {
        if(characterInfo.Gold >= 80) {
            if (cardObjectOnSelect != null) {
                characterInfo.CardList.Remove(cardDataOnSelect.Number);
                Destroy(cardObjectOnSelect);

                cardDataOnSelect = null;
                cardObjectOnSelect = null;
            }
            DeleteCardDescription();
            characterInfo.Gold -= 80;
            CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
        }
        else {
            Debug.Log("골드가 부족합니다.");
        }
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();
    }
}

