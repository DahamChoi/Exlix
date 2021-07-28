using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAreaLayerCardListController : MonoBehaviour {
    List<GameObject> cardObjectList = new List<GameObject>();

    void Start() {
        Init();
    }

    void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();

        DestroyList();
        foreach (int cardID in characterInfo.CardList) {
            cardObjectList.Add(FactoryManager.GetInstance().CreateInsideAreaInfoCardObject(cardID, transform));
        }
    }

    void DestroyList() {
        foreach (GameObject _gameObject in cardObjectList) {
            Destroy(_gameObject);
        }
        cardObjectList.Clear();
    }
}
