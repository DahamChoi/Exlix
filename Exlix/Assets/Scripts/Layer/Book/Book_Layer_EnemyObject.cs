using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Book_Layer_EnemyObject : MonoBehaviour, IObserver<UIStateInfo>, IPointerClickHandler {
    [SerializeField] GameObject glowEffect = null;
    [SerializeField] GameObject coverImage = null;
    int enemyID;
    bool isClicked;

    void Start() {
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
    }

    void Init(int _enemyID) {
        enemyID = _enemyID;
        //... 이미지 변경
        //... Collection 값 비교후 coverImage값 비활성화
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
        if(coverImage.activeSelf) return;
        isClicked = true;
        //... 데이터 전송
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();

    }

}
