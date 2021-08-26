using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Book_Layer_CardDescriptionUI : MonoBehaviour, IObserver<UIStateInfo> {
    [SerializeField] Text Cost = null;
    [SerializeField] Text Title = null;
    [SerializeField] Text Describe = null;
    [SerializeField] Text Property = null;

    void OnEnable() {
        ClearInfo();
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
        //카드 정보 입력
        Debug.Log("카드정보");
    }

    public void ClearInfo() {
        Cost.text = "";
        Title.text = "";
        Describe.text = "";
        Property.text = "";
    }
}
