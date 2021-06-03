using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataContainer : MonoBehaviour
{
    CardDataTemplate cardData;

    public void ReadData(CardDataTemplate cardData) {
        this.cardData = cardData;
        this.GetComponent<CardAppearance>().ReadText(cardData);
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
