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
        if (GameState.GetInstance().GetData<int>(InformationKeyDefine.CURRENT_SELECTED_CARD_OBJECT) == 0) return;
        //카드 정보 불러오기
        //카드 정보 입력GetComponent<UICardDescription>().Init(cardData);
        Debug.Log("카드정보");
    }
}
