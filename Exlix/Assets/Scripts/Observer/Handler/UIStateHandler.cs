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
        
    public CardDTO GetSelectedCard() {
        return Information.GetSelectedCard();
    }
}
