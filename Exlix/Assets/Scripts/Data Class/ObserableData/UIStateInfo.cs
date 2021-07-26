using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateInfo
{
    private UIStateData _UIStateData = new UIStateData();

    public void ProcessEvent() {

    }
    public void UpdateSelectedPortrait(PortraitDTO portraitData) {
        _UIStateData.SelectedPortrait = portraitData;
    }
    public void UpdateDestroyCard(CardDTO cardData) {
        _UIStateData.DestroyCard = cardData;
    }
    public void UpdateSelectedCard(CardDTO cardData) {
        _UIStateData.SelectedCard = cardData;
    }
    public CardDTO GetSelectedCard() {
        return _UIStateData.SelectedCard;
    }
    public PortraitDTO GetSelectedPortrait() {
        return _UIStateData.SelectedPortrait;
    }
}
