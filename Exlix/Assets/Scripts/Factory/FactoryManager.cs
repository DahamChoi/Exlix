using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour {
    [SerializeField] SQLiteManager _SQLiteManager;
    [SerializeField] CardObject CardObjectPrefab;
    [SerializeField] PortraitObject PortraitObjectPrefab;
   public CardObject CreateCardObject(int cardId, Transform parent) {
        CardObject cardObject = Instantiate<CardObject>(CardObjectPrefab, parent);
        CardDTO cardData = CardDAO.selectCard(_SQLiteManager, cardId);
        cardObject.init(cardData);
        return cardObject;
    }

    public PortraitObject CreatePortraitObject(int portraitId, Transform parent) {
        PortraitObject portraitObject = Instantiate<PortraitObject>(PortraitObjectPrefab, parent);
        PortraitDTO portraitData = PortraitDAO.selectPortrait(_SQLiteManager, portraitId);
        portraitObject.transform.parent = parent;
        portraitObject.init(portraitData);
        return portraitObject;
    }
}
