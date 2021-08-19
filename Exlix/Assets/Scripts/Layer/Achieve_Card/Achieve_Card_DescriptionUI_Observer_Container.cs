using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Achieve_Card_DescriptionUI_Observer_Container : MonoBehaviour, IObserver<UIStateInfo> {

    // Start is called before the first frame update
    void Start() {
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(UIStateInfo value) {
        if (GameState.GetInstance().GetData<GameObject>(InformationKeyDefine.CURRENT_SELECTED_CARD_OBJECT) == null) return;
        CardDTO cardData = GameState.GetInstance().GetData<GameObject>(InformationKeyDefine.CURRENT_SELECTED_CARD_OBJECT).GetComponent<Achieve_Card_CardObject>().cardData;
        GetComponent<UICardDescription>().Init(cardData);
    }
}
