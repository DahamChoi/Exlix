using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObject : MonoBehaviour {
    SelectionDTO selectionData;
    [SerializeField] Text selectionText;
    [SerializeField] Button selectionButton;
    [SerializeField] Transform sentencePannel;

    void Start() {
        selectionButton.onClick.AddListener(() => {
            FactoryManager.GetInstance().CreateSelectionTextObject(selectionData.Text, sentencePannel);
            if (selectionData.Action != 0) FactoryManager.GetInstance().CreateSentenceObject(selectionData.Action, transform.parent, sentencePannel);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
            //Data
        });
    }

    public void Init(SelectionDTO _selectionData, Transform _sentencePannel) {
        selectionData = _selectionData;
        sentencePannel = _sentencePannel;
        selectionText.text = _selectionData.Text;
    }
}
