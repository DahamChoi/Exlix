using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class CharacterGenerate_Deck_Info_UIController : MonoBehaviour, IPointerClickHandler {

    [SerializeField] Text CardExplain = null;
    [SerializeField] Text CardCost = null;
    [SerializeField] Text CardTitle = null;
    [SerializeField] Text CardFaction = null;
    [SerializeField] UIState _UIState = null;
    [SerializeField] Canvas m_canvas = null;
    GraphicRaycaster m_gr;
    PointerEventData m_ped;

    void Start() {
        m_gr = m_canvas.GetComponent<GraphicRaycaster>();
        m_ped = new PointerEventData(null);
    }

    public void updateCardExplain(CardDTO card) {
        CardExplain.text = card.Explanation;
        CardCost.text = card.Cost.ToString();
        CardTitle.text = card.Title;
        CardFaction.text = card.Property;
    }
    public void OnPointerClick(PointerEventData eventData) {
        m_ped.position = eventData.position;
        List<RaycastResult> results = new List<RaycastResult>();
        m_gr.Raycast(m_ped, results);
        if(results.Count > 0) {
            if (results[0].gameObject.transform.GetComponent<CardObject>()) {
                _UIState._UIStateHandler.UpdateSelectedCard(results[0].gameObject.transform.GetComponent<CardObject>().CardData);
                CardDTO card = _UIState._UIStateHandler.GetSelectedCard();
                CardExplain.text = card.Explanation;
                CardCost.text = card.Cost.ToString();
                CardTitle.text = card.Title;
                CardFaction.text = card.Property + " 속성";
            }
        }
    }
}
