using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CharacterMaintenance_Card_Layer : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] PlayerState _PlayerState = null;
    [SerializeField] UIState _UIState = null;
    [SerializeField] GameObject DeckListArea = null;
    [SerializeField] Button testButton = null;
    [SerializeField] GameObject DiscardArea = null;//해당 영역에 카드가 들어오고 enddrag실행되면 해당 충돌 오브젝트 삭제.
    [SerializeField] Transform popupTransform = null;
    List<int> myDeck = null;

    [SerializeField] Camera targetCamera = null;
    [SerializeField] Canvas m_canvas = null;

    GameObject CurrentPopup = null;
    GraphicRaycaster m_gr = null;
    PointerEventData m_ped = null;
    CardDTO cardDataOnSelect = null;
    GameObject cardObjectOnSelect = null;
    private void OnEnable() {
        Init();
        UpdateDeckList();
    }

    void Init() {
        m_gr = m_canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
    }

    public void OnPointerDown(PointerEventData eventData) {
        cardDataOnSelect = null;
        cardObjectOnSelect = null;
        m_ped.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        m_gr.Raycast(m_ped, results);
        if (results.Count > 0) {
            if (results[0].gameObject.transform.GetComponent<CardObject>()) {
                _UIState._UIStateHandler.UpdateSelectedCard(results[0].gameObject.transform.GetComponent<CardObject>().CardData);
                cardDataOnSelect = _UIState._UIStateHandler.GetSelectedCard();
                cardObjectOnSelect = results[0].gameObject;

                UpdateCardDescription(cardDataOnSelect);
                UpdateCardPosition(eventData);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        PlaceBackToDeck(cardObjectOnSelect, DeckListArea.transform);
    }

    public void OnDrag(PointerEventData eventData) {
        m_ped.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        m_gr.Raycast(m_ped, results);
        if (results.Count > 0) {
            if (results[0].gameObject.transform.GetComponent<CardObject>()) {
                UpdateCardPosition(eventData);
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData) {
        m_ped.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        m_gr.Raycast(m_ped, results);
        if (results.Count > 0) {
            if (results[0].gameObject.transform.GetComponent<CardObject>()) {
                _UIState._UIStateHandler.UpdateSelectedCard(results[0].gameObject.transform.GetComponent<CardObject>().CardData);
                cardDataOnSelect = _UIState._UIStateHandler.GetSelectedCard();
                cardObjectOnSelect = results[0].gameObject;

                UpdateCardDescription(cardDataOnSelect);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (DiscardArea.GetComponent<DiscardArea>().onDeleteArea) {
            DiscardCardFromDeck();
        }
        else {
            PlaceBackToDeck(cardObjectOnSelect, DeckListArea.transform);
        }
        cardDataOnSelect = null;
        cardObjectOnSelect = null;
    }

    void UpdateDeckList() {
        Transform[] childList = DeckListArea.GetComponentsInChildren<Transform>(true);
        if (childList != null) {
            for (int i = 1; i < childList.Length; i++) {
                if (childList[i] != transform) Destroy(childList[i].gameObject);
            }
        }
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
  
        for (int i = 0; i < characterInfo.CardList.Count; i++)
            FactoryManager.GetInstance().CreateCardObject(characterInfo.CardList[i], DeckListArea.transform);
    }

    void UpdateCardDescription(CardDTO card) {
        if (CurrentPopup) {
            Destroy(CurrentPopup);
            CurrentPopup = null;
        }
        CurrentPopup = FactoryManager.GetInstance().CreateCardDescriptionPopup(card, popupTransform);
    }
    void DiscardCardFromDeck() {
        Destroy(cardObjectOnSelect);
        _UIState._UIStateHandler.UpdateDestroyCard(cardDataOnSelect);
        cardDataOnSelect = null;
        cardObjectOnSelect = null;
        if (CurrentPopup) {
            Destroy(CurrentPopup);
            CurrentPopup = null;
        }
    }
    public void UpdateCardPosition(PointerEventData eventData) {
        cardObjectOnSelect.transform.SetParent(m_canvas.transform);
        cardObjectOnSelect.transform.position = new Vector3(targetCamera.ScreenToWorldPoint(eventData.position).x, targetCamera.ScreenToWorldPoint(eventData.position).y, 0.0f);
        cardObjectOnSelect.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    void PlaceBackToDeck(GameObject card, Transform area) {
        if (card) {
            card.transform.SetParent(area);
            card.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
