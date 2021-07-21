using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InsideAreaLayerController : MonoBehaviour, IObserver<AreaStateInfo>, IObserver<Information> {
    [SerializeField] Transform selectionContainer = null;
    [SerializeField] Transform sentencePannel = null;
    [SerializeField] ScrollRect pannelScroll = null;
    [SerializeField] AreaState areaState = null;

    private AreaDTO AreaInfo;
    private EventDTO CurrentEvent = null;

    private void Awake() {
        areaState._AreaStateInfoHandler.Subscribe(this);
        SceneState.GetInstance()._InformationHandler.Subscribe(this);
    }

    private void OnEnable() {
        if(null == CurrentEvent) {
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
    
    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(Information information) {
        AreaInfo = information.GetData<AreaDTO>(InformationKeyDefine.CURRENT_AREA_NUMBER_KEY);

        //Debug.Log(information.GetData<SelectionDTO>(InformationKeyDefine.CURRENT_SELECTION_DATA).Number);
    }

    public void OnNext(AreaStateInfo value) {
        // FactoryManager.GetInstance().CreateSelectionTextObject(value.selectionData.Text, sentencePannel);
        // if (value.selectionData.Action != 0) FactoryManager.GetInstance().CreateSentenceObject(value.selectionData.Action, this, sentencePannel);
        // LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
        // pannelScroll.verticalNormalizedPosition = 0;
    }
}
