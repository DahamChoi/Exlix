using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : Singleton<FactoryManager> {

    public GameObject CreateCardObject(int cardId, Transform parent) {
        GameObject cardObjectPrefab = Resources.Load("Prefabs/CardPrefab") as GameObject;
        GameObject cardObject = Instantiate<GameObject>(cardObjectPrefab, parent);
        CardDTO cardData = CardDAO.SelectCard(cardId);
        cardObject.GetComponent<CardObject>().init(cardData);
        return cardObject;
    }

    public List<PortraitObject> CreatePortraitObject(Transform parent) {
        List<PortraitObject> portraitObjectList = new List<PortraitObject>();
        List<PortraitDTO> portraitData = PortraitDAO.SelectAllPortrait();

        GameObject portraitPrefab = Resources.Load("Prefabs/Portrait") as GameObject;

        for (int i = 0; i < portraitData.Count; i++) {
            Debug.Log(portraitData[i].Number);
            GameObject portraitObject = Instantiate<GameObject>(portraitPrefab, parent);
            portraitObject.transform.parent = parent;
            portraitObject.GetComponent<PortraitObject>().init(portraitData[i]);

            //portraitObjectList.Add(portraitObject);
        }
        return portraitObjectList;
    }

    public GameObject CreateSelectAreaPopup(AreaDTO areaDTO, Transform parent) {
        GameObject selectAreaPopupPrefab = Resources.Load("Prefabs/SelectAreaPopup") as GameObject;
        GameObject selectAreaPopup = Instantiate<GameObject>(selectAreaPopupPrefab, parent);
        selectAreaPopup.GetComponent<SelectAreaPopup>().Init(areaDTO);
        return selectAreaPopup;
    }

    public GameObject CreateSentenceObject(int sentenceId, Transform selectionContainer, Transform parent) {
        GameObject sentenceObjectPrefab = Resources.Load("Prefabs/SentenceText") as GameObject;
        GameObject sentenceObject = Instantiate<GameObject>(sentenceObjectPrefab, parent);
        SentenceDTO sentenceData = SentenceDAO.SelectSentence(sentenceId);
        sentenceObject.GetComponent<SentenceObject>().Init(sentenceData, selectionContainer);
        return sentenceObject;
    }

    public GameObject CreateSentenceImageObject(string imagePath, Transform parent) {
        GameObject sentenceImageObjectPrefab = Resources.Load("Prefabs/SentenceImage") as GameObject;
        GameObject sentenceImageObject = Instantiate<GameObject>(sentenceImageObjectPrefab, parent);
        sentenceImageObject.GetComponent<SentenceImageObject>().Init(imagePath);
        return sentenceImageObject;
    }

    public GameObject CreateSelectionObject(int selectionId, Transform sentencePannel, Transform parent) {
        GameObject selectionObjectPrefab = Resources.Load("Prefabs/SelectionButton") as GameObject;
        GameObject selectionObject = Instantiate<GameObject>(selectionObjectPrefab, parent);
        SelectionDTO selectionData = SelectionDAO.SelectSelection(selectionId);
        selectionObject.GetComponent<SelectionObject>().Init(selectionData, sentencePannel);
        return selectionObject;
    }

        public GameObject CreateSelectionTextObject(string selectionText, Transform parent) {
        GameObject selectionTextObjectPrefab = Resources.Load("Prefabs/SelectionText") as GameObject;
        GameObject selectionTextObject = Instantiate<GameObject>(selectionTextObjectPrefab, parent);
        selectionTextObject.GetComponent<SelectionTextObject>().Init(selectionText);
        return selectionTextObject;
    }
}
