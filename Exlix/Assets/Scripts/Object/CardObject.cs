using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {
    public CardDTO CardData;

    [SerializeField] Text ExplainText = null;
    [SerializeField] Text CostText = null;

    public void init(CardDTO cardData) {
        CardData = cardData;

        ExplainText.text = CardData.Title;
        CostText.text = CardData.Cost.ToString();
    }
}
