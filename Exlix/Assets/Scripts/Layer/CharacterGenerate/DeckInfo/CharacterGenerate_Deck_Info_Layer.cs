using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterGenerate_Deck_Info_Layer : MonoBehaviour {
    [SerializeField] PlayerState _PlayerState = null;
    [SerializeField] GameObject DeckListArea = null;
    [SerializeField] Button testButton = null;

    private void Start() {
        testButton.onClick.AddListener(() => {
            UpdateDeckList();
        });
    }
    
    void Update() {

    }

    void UpdateDeckList() {
    StartDeckDTO startDeck = SceneState.GetInstance()._InformationHandler.GetData<StartDeckDTO>(InformationKeyDefine.CURRENT_START_DECK_DATA);
        Transform[] childList = DeckListArea.GetComponentsInChildren<Transform>(true);
        if (childList != null) {
            for (int i = 1; i < childList.Length; i++) {
                if (childList[i] != transform) Destroy(childList[i].gameObject);
            }
        }

        for (int i = 0; i < startDeck.CardList.Count; i++)
            FactoryManager.GetInstance().CreateCardObject(startDeck.CardList[i], DeckListArea.transform);
    }
}
