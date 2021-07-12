using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerate_Deck_Info_Layer : MonoBehaviour
{
    [SerializeField] PlayerState _PlayerState;
    [SerializeField] GameObject DeckListArea;
    [SerializeField] Button testButton;

    private void Start() {

        testButton.onClick.AddListener(() => {
            UpdateDeckList();
        });
    }
    void Update()
    {
        
    }

    void UpdateDeckList() {
        Transform[] childList = DeckListArea.GetComponentsInChildren<Transform>(true);
        if(childList != null) {
            for(int i=1; i < childList.Length; i++) {
                if (childList[i] != transform) Destroy(childList[i].gameObject);
            }
        }
        
        StartDeckDTO startDeck = _PlayerState._PlayerStateInfoHandler.GetCurrentStartDeck();
        for(int i=0; i<startDeck.CardList.Count;i++)
        FactoryManager.GetInstance().CreateCardObject(startDeck.CardList[i].Number,DeckListArea.transform);
    }
}
