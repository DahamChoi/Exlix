using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObject : MonoBehaviour, IObserver<Information> {
    SelectionDTO selectionData;
    [SerializeField] Text selectionText = null;
    [SerializeField] Button selectionButton = null;
    //AreaState areaState;

    void Start() {
        // areaState = GameObject.Find("AreaState").GetComponent<AreaState>();
        // areaState._AreaStateInfoHandler.Subscribe(this);
        // areaState._AreaStateInfoHandler.CreateSelection();
        SceneState.GetInstance()._InformationHandler.Subscribe(this);
        selectionButton.onClick.AddListener(() => {
            //areaState._AreaStateInfoHandler.SelectSelection(selectionData);
            SceneState.GetInstance()._InformationHandler.InsertData<SelectionDTO>(InformationKeyDefine.CURRENT_SELECTION_DATA, selectionData);
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

    public void OnNext(Information value) {
        Debug.Log("Data in");
        // if (value.isSelected) {
        //     Destroy(this.gameObject);
        // }
    }
}
