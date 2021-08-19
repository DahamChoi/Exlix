using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICardDescription : MonoBehaviour
{
    [SerializeField] Text Cost = null;
    [SerializeField] Text Title = null;
    [SerializeField] Text Describe = null;
    [SerializeField] Text Property = null;
    public void Init(CardDTO card) {
        Cost.text = card.Cost.ToString();
        Title.text = card.Title;
        Describe.text = card.Explanation;
        Property.text = card.Property;
    }

    public void ClearInfo() {
        Cost.text = "";
        Title.text = "";
        Describe.text = "";
        Property.text = "";
    }
}
