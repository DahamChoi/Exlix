using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateHandler : ObserableHandler<UIStateInfo>
{
    public UIStateHandler() {
        Information = new UIStateInfo();
    }

    public void UpdateDestroyCard(CardDTO cardData) {
        Information.UpdateDestroyCard(cardData);
        base.NotifyObservers();
    }

    public void UpdateSelectedCard(CardDTO cardData) {
        Information.UpdateSelectedCard(cardData);
        base.NotifyObservers();
    }
    public void UpdateSelectedPortrait(PortraitDTO portraitData) {
        Information.UpdateSelectedPortrait(portraitData);
        base.NotifyObservers();
    }
    public PortraitDTO GetSelectedPortrait() {
        return Information.GetSelectedPortrait();
    }
    public CardDTO GetSelectedCard() {
        return Information.GetSelectedCard();
    }
}
