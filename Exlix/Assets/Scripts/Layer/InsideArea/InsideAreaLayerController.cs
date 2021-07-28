using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InsideAreaLayerController : MonoBehaviour {
    [SerializeField] Transform selectionContainer = null;
    [SerializeField] Transform sentencePannel = null;
    [SerializeField] ScrollRect pannelScroll = null;
    private AreaDTO AreaInfo;
    private EventDTO CurrentEvent = null;
    bool isInit = true;

    void Start() {
        AreaInfo = GameState.GetInstance().GetData<AreaDTO>(InformationKeyDefine.CURRENT_AREA_NUMBER_KEY);
    }

    private void OnEnable() {
        if (null == CurrentEvent) {
            InitEvent();
        }
    }


    private void InitEvent() {
        int percent = UnityEngine.Random.Range(0, 100);
        // List<EventDTO> cadidateList = EventDAO.SelectEventByQuery(AreaInfo.Region, AreaInfo.Level, percent <= AreaInfo.MainPercentage);
        List<EventDTO> cadidateList = EventDAO.SelectEventByQuery("empire", 1, true);
        int selectEventIndex = UnityEngine.Random.Range(0, cadidateList.Count);
        CurrentEvent = cadidateList[selectEventIndex];

        CreateSentence(CurrentEvent.StartSentece);
    }

    public void CreateSentence(int sentenceId) {
        FactoryManager.GetInstance().CreateSentenceObject(sentenceId, this, sentencePannel);
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
        pannelScroll.verticalNormalizedPosition = 1;
    }

    public Transform GetSelectionContainer() {
        return selectionContainer;
    }

    public void SelectSelection(SelectionDTO selectionData) {
        FactoryManager.GetInstance().CreateSelectionTextObject(selectionData.Text, sentencePannel);
        
        //선택지가 또 다른 Sentence를 갖고있는가
        if (selectionData.Action != 0) {
            FactoryManager.GetInstance().CreateSentenceObject(selectionData.Action, this, sentencePannel);
        }

        //UI새로고침
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
        pannelScroll.verticalNormalizedPosition = 0;
    }
}
