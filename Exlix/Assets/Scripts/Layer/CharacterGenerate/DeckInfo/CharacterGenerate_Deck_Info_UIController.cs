using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class CharacterGenerate_Deck_Info_UIController : MonoBehaviour, IPointerClickHandler {
  
    [SerializeField] UIState _UIState = null;
    [SerializeField] Canvas m_canvas = null;
    [SerializeField] Transform PopupTransform = null;
    GraphicRaycaster m_gr;
    PointerEventData m_ped;
    GameObject currentDescriptionPopup;
    void Start() {
        m_gr = m_canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
    }

    public void CardDescriptionPopup(CardDTO card) {
        if (currentDescriptionPopup) {
            Destroy(currentDescriptionPopup);
            currentDescriptionPopup = null;
        }
        FactoryManager.GetInstance().CreateCardDescriptionPopup(card, PopupTransform);
    }
    public void OnPointerClick(PointerEventData eventData) {
        m_ped.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        m_gr.Raycast(m_ped, results);
        if(results.Count > 0) {
            if (results[0].gameObject.transform.GetComponent<CardObject>()) {
                _UIState._UIStateHandler.UpdateSelectedCard(results[0].gameObject.transform.GetComponent<CardObject>().CardData);
                CardDTO card = _UIState._UIStateHandler.GetSelectedCard();
                CardDescriptionPopup(card);
            }
        }
    }
}
