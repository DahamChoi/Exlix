using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsideAreaInfoCardPopupObject : MonoBehaviour {
    [SerializeField] Text title = null;
    [SerializeField] Text cost = null;
    [SerializeField] Text property = null;
    [SerializeField] Text explain = null;
    CardDTO cardData;
    public void Init(CardDTO _cardData){
        cardData = _cardData;
        title.text = cardData.Title;
        cost.text = cardData.Cost.ToString();
        property.text = cardData.Property;
        explain.text = cardData.Explanation;
    }
}
