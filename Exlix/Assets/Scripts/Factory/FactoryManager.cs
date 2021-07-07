using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour {
    [SerializeField] SQLiteManager _SQLiteManager;
    [SerializeField] CardObject CardObjectPrefab;
    [SerializeField] PortraitObject PortraitObjectPrefab;
    public CardObject CreateCardObject(int cardId, Transform parent) {
        CardObject cardObject = Instantiate<CardObject>(CardObjectPrefab, parent);
        CardDTO cardData = CardDAO.SelectCard(_SQLiteManager, cardId);
        cardObject.init(cardData);
        return cardObject;
    }

    public List<PortraitObject> CreatePortraitObject(Transform parent) {
        List<PortraitObject> portraitObjectList = new List<PortraitObject>();
        List<PortraitDTO> portraitData = PortraitDAO.SelectPortrait(_SQLiteManager);

        for (int i = 0; i < portraitData.Count; i++) {
            Debug.Log(portraitData[i].Number);
            PortraitObject portraitObject = Instantiate<PortraitObject>(PortraitObjectPrefab, parent);
            portraitObject.transform.parent = parent;
            portraitObject.init(portraitData[i]);

            portraitObjectList.Add(portraitObject);
        }
        return portraitObjectList;
    }

    public List<StartPackDTO> LoadStartPackData() {
        return StartPackDAO.totalStartPack(_SQLiteManager);
    }
}
