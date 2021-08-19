using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardObject : MonoBehaviour{
    public CardDTO cardData;

    [SerializeField] Text TitleText = null;
    [SerializeField] Text CostText = null;
    [SerializeField] public GameObject glowEffect = null;
    public void Init(CardDTO cardData) {
        this.cardData = cardData;

        TitleText.text = this.cardData.Title;
        CostText.text = this.cardData.Cost.ToString();
    }
}
