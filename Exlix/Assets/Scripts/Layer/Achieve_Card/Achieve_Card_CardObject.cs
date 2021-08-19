using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Achieve_Card_CardObject : CardObject, IObserver<UIStateInfo>, IPointerClickHandler {
    bool isClicked = false;

    public void OnPointerClick(PointerEventData eventData) {
        isClicked = true;
        GameState.GetInstance().UpsertData<GameObject>(InformationKeyDefine.CURRENT_SELECTED_CARD_OBJECT, this.gameObject);
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();
    }

    void Start() {
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
    }
    
    void UpdateEffect() {
        glowEffect.SetActive(isClicked);
        isClicked = false;
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(UIStateInfo value) {
        if(this == null) return;
        UpdateEffect();
    }
}
