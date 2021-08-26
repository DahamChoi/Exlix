using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Book_Layer_EnemyDescriptionUI : MonoBehaviour, IObserver<UIStateInfo>
{
    [SerializeField] Text Title = null;
    [SerializeField] Text Describe = null;

    void Start() {
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
        ClearInfo();
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(UIStateInfo value) {
        if (GameState.GetInstance().GetData<int>(InformationKeyDefine.CURRENT_SELECTED_ENEMY_OBJECT) == 0) {
            ClearInfo();
            return;
        }
        Debug.Log("적 정보");
        //..데이터 가져와서 데이터 입력
    }

    public void ClearInfo() {
        Title.text = "";
        Describe.text = "";
    }
}
