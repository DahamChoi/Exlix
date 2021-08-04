using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : Singleton<FactoryManager> {

    public GameObject CreateCardObject(int cardId, Transform parent) {
        GameObject cardObjectPrefab = Resources.Load("Prefabs/CardPrefab") as GameObject;
        GameObject cardObject = Instantiate<GameObject>(cardObjectPrefab, parent);
        CardDTO cardData = CardDAO.SelectCard(cardId);
        cardObject.GetComponent<CardObject>().Init(cardData);
        return cardObject;
    }

    public List<PortraitObject> CreatePortraitObject(Transform parent) {
        List<PortraitObject> portraitObjectList = new List<PortraitObject>();
        List<PortraitDTO> portraitData = PortraitDAO.SelectAllPortrait();

        GameObject portraitPrefab = Resources.Load("Prefabs/Portrait") as GameObject;

        for (int i = 0; i < portraitData.Count; i++) {

            GameObject portraitObject = Instantiate<GameObject>(portraitPrefab, parent);
            portraitObject.transform.SetParent(parent);
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

    public GameObject CreateSentenceObject(int sentenceId, InsideAreaLayerController insideAreaLayerController, Transform parent) {
        GameObject sentenceObjectPrefab = Resources.Load("Prefabs/SentenceText") as GameObject;
        GameObject sentenceObject = Instantiate<GameObject>(sentenceObjectPrefab, parent);
        SentenceDTO sentenceData = SentenceDAO.GetSelectedSentenceInfo(sentenceId);
        sentenceObject.GetComponent<SentenceObject>().Init(sentenceData, insideAreaLayerController);
        return sentenceObject;
    }

    public GameObject CreateSentenceImageObject(string imagePath, Transform parent) {
        GameObject sentenceImageObjectPrefab = Resources.Load("Prefabs/SentenceImage") as GameObject;
        GameObject sentenceImageObject = Instantiate<GameObject>(sentenceImageObjectPrefab, parent);
        sentenceImageObject.GetComponent<SentenceImageObject>().Init(imagePath);
        return sentenceImageObject;
    }

    public GameObject CreateSentenceSmallImageObject(string sentenceString, string imagePath, Transform parent) {
        GameObject sentenceSmallImageObjectPrefab = Resources.Load("Prefabs/SentenceSmallImage") as GameObject;
        GameObject sentenceSmallImageObject = Instantiate<GameObject>(sentenceSmallImageObjectPrefab, parent);
        sentenceSmallImageObject.GetComponent<SentenceSmallImageObject>().Init(sentenceString, imagePath);
        return sentenceSmallImageObject;
    }

    public GameObject CreateSelectionObject(int selectionId, Transform parent) {
        GameObject selectionObjectPrefab = Resources.Load("Prefabs/SelectionButton") as GameObject;
        GameObject selectionObject = Instantiate<GameObject>(selectionObjectPrefab, parent);
        SelectionDTO selectionData = SelectionDAO.GetSelectedSelectionInfo(selectionId);
        selectionObject.GetComponent<SelectionObject>().Init(selectionData);
        return selectionObject;
    }

    public GameObject CreateSelectionTextObject(string selectionText, Transform parent) {
        GameObject selectionTextObjectPrefab = Resources.Load("Prefabs/SelectionText") as GameObject;
        GameObject selectionTextObject = Instantiate<GameObject>(selectionTextObjectPrefab, parent);
        selectionTextObject.GetComponent<SelectionTextObject>().Init(selectionText);
        return selectionTextObject;
    }

    public GameObject CreateCardDescriptionPopup(CardDTO card, Transform parent) {
        GameObject CardDescriptionPopupPrefab = Resources.Load("Prefabs/CardDescribe_Popup") as GameObject;
        GameObject CardDescriptionPopup = Instantiate<GameObject>(CardDescriptionPopupPrefab, parent);
        CardDescriptionPopup.GetComponent<UICardDescription>().Init(card);
        return CardDescriptionPopup;
    }

    public GameObject CreateSelectedSkillPopup(SkillDTO skillData, Transform parent) {
        GameObject skillPopupPrefab = Resources.Load("Prefabs/SkillPopup") as GameObject;
        GameObject skillPopupObject = Instantiate<GameObject>(skillPopupPrefab, parent);
        skillPopupObject.GetComponent<SkillPopupObject>().Init(skillData);
        return skillPopupObject;
    }

    public GameObject CreateInsideAreaInfoCardObject(int cardId, Transform parent) {
        GameObject cardObjectPrefab = Resources.Load("Prefabs/InsideAreaInfoCardPrefab") as GameObject;
        GameObject cardObject = Instantiate<GameObject>(cardObjectPrefab, parent);
        CardDTO cardData = CardDAO.SelectCard(cardId);
        cardObject.GetComponent<InsideAreaInfoCardObject>().Init(cardData);
        return cardObject;
    }

    public GameObject CreateInsideAreaInfoCardDescriptionPopup(CardDTO card, Transform parent) {
        GameObject CardDescriptionPopupPrefab = Resources.Load("Prefabs/InsideAreaCardInfoPopup") as GameObject;
        GameObject CardDescriptionPopup = Instantiate<GameObject>(CardDescriptionPopupPrefab, parent);
        CardDescriptionPopup.GetComponent<InsideAreaInfoCardPopupObject>().Init(card);
        return CardDescriptionPopup;
    }

    public GameObject CreateLineObject<T>(Vector3 start, Vector3 end, T data, Transform parent) {
        GameObject LinePrefab = Resources.Load("Prefabs/LineRenderer") as GameObject;
        GameObject Line = Instantiate<GameObject>(LinePrefab, parent);
        Line.GetComponent<RenderBridge>().Init(start, end, data);
        return Line;
    }

    public GameObject CreateEquipmentPopup(EquipmentDTO equipmentData, Transform parent) {
        GameObject equipmentPopupPrefab = Resources.Load("Prefabs/EquipmentPopup") as GameObject;
        GameObject equipmentPopup = Instantiate<GameObject>(equipmentPopupPrefab, parent);
        equipmentPopup.GetComponent<EquipmentPopupObject>().Init(equipmentData);
        return equipmentPopup;
    }

    public GameObject CreateEquipmentTree(Transform parent) {
        GameObject equipmentTreePrefab = new GameObject();
        if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.HEAD_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/HeadTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.UPPER_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/UpperTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.UNDER_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/UnderTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.WEAPON_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/WeaponTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.ACCESSORY_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/AccessoryTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.ODDMENT_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/OddmentTree") as GameObject;
        }
        GameObject equipmentTree = Instantiate<GameObject>(equipmentTreePrefab, parent);
        return equipmentTree;
    }
}
