using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {
    private Card CardData;

    [SerializeField] Text ExplainText;
    [SerializeField] Text CostText;

    public void init(Card cardData) {
        CardData = cardData;

        ExplainText.text = CardData.Title;
        CostText.text = CardData.Cost.ToString();
    }
}
