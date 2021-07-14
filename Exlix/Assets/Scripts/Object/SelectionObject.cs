using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObject : MonoBehaviour {
    SelectionDTO selectionData;
    [SerializeField] Text selectionText;
    [SerializeField] Button selectionButton;
    StageController stageController;

    void Start() {
        selectionButton.onClick.AddListener(() => {
            FactoryManager.GetInstance().CreateSelectionTextObject(selectionData.Text, stageController.sentencePannel);
            if (selectionData.Action != 0) FactoryManager.GetInstance().CreateSentenceObject(selectionData.Action, stageController, stageController.sentencePannel);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)stageController.sentencePannel);
            stageController.pannelScroll.verticalNormalizedPosition = 0;
            //Data
        });
    }

    public void Init(SelectionDTO _selectionData, StageController _stageController) {
        selectionData = _selectionData;
        stageController = _stageController;
        selectionText.text = selectionData.Text;
    }
}
