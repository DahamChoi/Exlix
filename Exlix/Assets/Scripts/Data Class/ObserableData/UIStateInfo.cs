using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateInfo
{
    private UIStateData _UIStateData = new UIStateData();

    public void ProcessEvent() {

    }
    public void UpdateSelectedCard(CardDTO cardData) {
        _UIStateData.SelectedCard = cardData;
    }
    public CardDTO GetSelectedCard() {
        return _UIStateData.SelectedCard;
    }
}
