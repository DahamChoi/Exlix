using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICardDescription : MonoBehaviour
{
    [SerializeField] Text Cost;
    [SerializeField] Text Title;
    [SerializeField] Text Describe;
    [SerializeField] Text Property;
    public void Init(CardDTO card) {
        Cost.text = card.Cost.ToString();
        Title.text = card.Title;
        Describe.text = card.Explanation;
        Property.text = card.Property;
    }
}
