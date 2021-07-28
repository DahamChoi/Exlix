using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObject : MonoBehaviour {
    SelectionDTO selectionData;
    [SerializeField] Text selectionText = null;
    [SerializeField] Button selectionButton = null;
    SelectionController selectionController;

    void Start() {
        selectionController = transform.parent.GetComponent<SelectionController>();
        selectionController.AddSelection(this.gameObject);
        selectionButton.onClick.AddListener(() => {
            selectionController.SelectSelection(selectionData);
            selectionController.Destroy();
        });
    }

    public void Init(SelectionDTO _selectionData) {
        selectionData = _selectionData;
        selectionText.text = selectionData.Text;
    }
}
