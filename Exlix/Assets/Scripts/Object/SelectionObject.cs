using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObject : MonoBehaviour, IObserver<Information> {
    SelectionDTO selectionData;
    [SerializeField] Text selectionText = null;
    [SerializeField] Button selectionButton = null;


    void Start() {
        SceneState.GetInstance()._InformationHandler.Subscribe(this);
        SceneState.GetInstance()._InformationHandler.InsertData<bool>(InformationKeyDefine.IS_SELECTION_SELECTED, false);
        selectionButton.onClick.AddListener(() => {
            SceneState.GetInstance()._InformationHandler.InsertData<SelectionDTO>(InformationKeyDefine.CURRENT_SELECTION_DATA, selectionData);
            SceneState.GetInstance()._InformationHandler.InsertData<bool>(InformationKeyDefine.IS_SELECTION_SELECTED, true);
            SceneState.GetInstance()._InformationHandler.NotifyObservers();
        });
    }

    public void Init(SelectionDTO _selectionData) {
        selectionData = _selectionData;
        selectionText.text = selectionData.Text;
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(Information information) {
        if (information.GetData<bool>(InformationKeyDefine.IS_SELECTION_SELECTED)) {
            Destroy(this.gameObject);
        }
    }
}
