using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Book_Layer_CardObject : MonoBehaviour, IObserver<UIStateInfo>, IPointerClickHandler {
    [SerializeField] Text TitleText = null;
    [SerializeField] Text CostText = null;
    [SerializeField] public GameObject glowEffect = null;
    int cardId;
    bool isClicked = false;

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
        glowEffect.SetActive(isClicked);
        isClicked = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        isClicked = true;
        //... 데이터 전송
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();
    }

    void Init(int _cardId) {
        cardId = _cardId;
        //... 이미지 변경
    }
}
