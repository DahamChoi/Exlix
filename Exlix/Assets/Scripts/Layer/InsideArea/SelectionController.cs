using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour, IObserver<InsideAreaState> {
    [SerializeField] SelectionButton selectionButton1;
    [SerializeField] SelectionButton selectionButton2;
    [SerializeField] SelectionButton selectionButton3;

    List<SelectionButton> selectionButtonList = new List<SelectionButton>();

    private List<SelectionDTO> selectionList;

    void Awake() {
        SceneState.GetInstance()._InsideAreaHandler.Subscribe(this);
    }

    void Start() {
        selectionButtonList.Add(selectionButton1);
        selectionButtonList.Add(selectionButton2);
        selectionButtonList.Add(selectionButton3);

        foreach(var it in selectionButtonList) {
            it.gameObject.SetActive(false);
        }
    }

    void Update() {
        
    }

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(InsideAreaState value) {
        if(selectionList != value.selectionList) {
            for(int i = 0; i < 3; i++) {
                if(i >= value.selectionList.Count) {
                    selectionButtonList[i].button.gameObject.SetActive(false);
                }
                else {
                    SelectionButton sb = selectionButtonList[i];
                    sb.button.gameObject.SetActive(true);
                    sb.buttonText.text = value.selectionList[i].Text;
                    sb.button.onClick.RemoveAllListeners();
                    sb.button.onClick.AddListener(() => {
                        SceneState.GetInstance()._InsideAreaHandler.AddSentence(value.selectionList[i].Action);
                        SceneState.GetInstance()._InsideAreaHandler.ClearSelection();
                    });
                }
            }
        }

        selectionList = value.selectionList;
    }
}
