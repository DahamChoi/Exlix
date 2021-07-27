using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour {
    public CardDTO CardData;

    [SerializeField] Text TitleText = null;
    [SerializeField] Text CostText = null;

    public void Init(CardDTO cardData) {
        CardData = cardData;

        TitleText.text = CardData.Title;
        CostText.text = CardData.Cost.ToString();
    }
}
