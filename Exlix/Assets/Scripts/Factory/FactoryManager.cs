using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoBehaviour {
    [SerializeField] SQLiteManager _SQLiteManager;
    [SerializeField] CardObject CardObjectPrefab;

   public CardObject CreateCardObject(int cardId, Transform parent) {
        CardObject cardObject = Instantiate<CardObject>(CardObjectPrefab, parent);
        CardDTO cardData = CardDao.selectCard(_SQLiteManager, cardId);
        cardObject.init(cardData);
        return cardObject;
    }
}
