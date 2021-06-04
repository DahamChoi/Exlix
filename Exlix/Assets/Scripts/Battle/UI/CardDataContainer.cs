using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataContainer : MonoBehaviour
{
    public CardDataTemplate cardData;
    public int cardIndexNum;

    float canvasHeight;
    bool isPlayed;

    public void ReadData(CardDataTemplate cardData) {
        this.cardData = cardData;
        this.GetComponent<CardAppearance>().ReadText(cardData);
    }

    public bool isTargeting() {
		if (cardData.GetCardData("AttackTarget") == "지정적") {
            return true;
		}
        return false;
	}

    public void PlayCard() {
        if (!isPlayed) return;
        GameObject.Find("BattleManager").GetComponent<BattleManager>().PlayCard(this.gameObject, null);
        Invoke("DestroyCard", 0.5f);
    }

    void DestroyCard() {
        this.gameObject.GetComponent<CardHand>().CardObjects.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        isPlayed = false;
        canvasHeight = this.gameObject.transform.parent.transform.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update() {
        isPlayed = (this.transform.position.y > -1);
        Debug.Log(cardData.GetCardData("ContinuousTurn"));
    }
}
