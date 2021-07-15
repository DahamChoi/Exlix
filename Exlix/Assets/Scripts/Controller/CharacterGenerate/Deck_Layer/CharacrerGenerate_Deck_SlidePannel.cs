using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacrerGenerate_Deck_SlidePannel : MonoBehaviour, IBeginDragHandler, IDragHandler {
    [SerializeField] CharacterGenerate_Deck_InfoController deckInfoController = null;
    Vector2 startPos;
    Vector2 movedPos;
    bool is_moved;

    public void OnBeginDrag(PointerEventData eventData) {
        startPos = eventData.position;
        is_moved = false;
    }

    public void OnDrag(PointerEventData eventData) {
        if (is_moved) return;
        movedPos = eventData.position - startPos;
        if (movedPos.x > 300) {
            deckInfoController.PreviousDeck();
            is_moved = true;
        }
        else if (movedPos.x < -300) {
            deckInfoController.NextDeck();
            is_moved = true;
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
