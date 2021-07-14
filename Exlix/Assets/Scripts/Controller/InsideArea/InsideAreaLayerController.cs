using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InsideAreaLayerController : MonoBehaviour, IObserver<AreaStateInfo> {
    [SerializeField] public Transform selectionContainer;
    [SerializeField] public Transform sentencePannel;
    [SerializeField] public ScrollRect pannelScroll;
    [SerializeField] AreaState areaState;
    // Start is called before the first frame update
    void Start() {
        areaState._AreaStateInfoHandler.Subscribe(this);
        CreateSentence(1);
    }

    // Update is called once per frame
    void Update() {

    }

    public void CreateSentence(int sentenceId) {
        FactoryManager.GetInstance().CreateSentenceObject(sentenceId, this, sentencePannel);
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
        pannelScroll.verticalNormalizedPosition = 0;
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(AreaStateInfo value) {
        FactoryManager.GetInstance().CreateSelectionTextObject(value.selectionData.Text, sentencePannel);
        if (value.selectionData.Action != 0) FactoryManager.GetInstance().CreateSentenceObject(value.selectionData.Action, this, sentencePannel);
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
        pannelScroll.verticalNormalizedPosition = 0;
    }
}
