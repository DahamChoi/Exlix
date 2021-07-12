using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardAppearance : MonoBehaviour {

    [SerializeField] Text property;
    [SerializeField] Text cost;
    [SerializeField] Text title;
    [SerializeField] Text explain;

    public void ReadText(CardDataTemplate cardData) {
        property.text = cardData.GetCardData("Property");
        cost.text = cardData.GetCardData("Cost");
        title.text = cardData.GetCardData("Title");
        explain.text = cardData.GetCardData("Explanation").Replace("<br>", "\n");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
