using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObject : MonoBehaviour, IObserver<AreaStateInfo> {
    SelectionDTO selectionData;
    [SerializeField] Text selectionText = null;
    [SerializeField] Button selectionButton = null;
    AreaState areaState;

    void Start() {
        areaState = GameObject.Find("AreaState").GetComponent<AreaState>();
        areaState._AreaStateInfoHandler.Subscribe(this);
        areaState._AreaStateInfoHandler.CreateSelection();

        selectionButton.onClick.AddListener(() => {
            areaState._AreaStateInfoHandler.SelectSelection(selectionData);
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

    public void OnNext(AreaStateInfo value) {
        if (value.isSelected) {
            Destroy(this.gameObject);
        }
    }
}
