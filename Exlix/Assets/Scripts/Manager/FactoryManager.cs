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

    public GameObject CreateSprite(Transform parent) {
        GameObject spritePrefab = Resources.Load("Prefabs/Image") as GameObject;
        GameObject sprite = Instantiate<GameObject>(spritePrefab, parent);
        return sprite;
    }

    public GameObject CreateText(Transform parent) {
        GameObject textPrefab = Resources.Load("Prefabs/Text") as GameObject;
        GameObject text = Instantiate<GameObject>(textPrefab, parent);
        return text;
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
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.SHIRT_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/UpperTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.PANTS_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/UnderTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.WEAPON_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/WeaponTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.TRINKET_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/AccessoryTree") as GameObject;
        }
        else if (GameState.GetInstance().GetData<string>(InformationKeyDefine.CURRENT_SELECTED_EQUIPMENT_PART) == InformationKeyDefine.ETC_PART) {
            equipmentTreePrefab = Resources.Load("Prefabs/OddmentTree") as GameObject;
        }
        GameObject equipmentTree = Instantiate<GameObject>(equipmentTreePrefab, parent);
        return equipmentTree;
    }

    public GameObject CreateAchieveCard (CardDTO cardData, Transform parent) {
        GameObject achieveCardPrefab = Resources.Load("Prefabs/AchieveCardObjectPrefab") as GameObject;
        GameObject achieveCardObject = Instantiate(achieveCardPrefab, parent);
        achieveCardObject.GetComponent<Achieve_Card_CardObject>().Init(cardData);
        return achieveCardObject;
    }

    public GameObject CreateBookCard (Transform parent) {
        GameObject bookCardPrefab = Resources.Load(" ") as GameObject;
        return bookCardPrefab;
    }

    public GameObject CreateBookEnemy (Transform parent) {
        GameObject bookEnemyPrefab = Resources.Load(" ") as GameObject;
        return bookEnemyPrefab;
    }

    public GameObject CreateBookEnding (Transform parent) {
        GameObject bookEndingPrefab = new GameObject();
        return bookEndingPrefab;
    }

    public GameObject CreateBookEndingPopup (Transform parent) {
        GameObject bookEndingPopupPrefab = new GameObject();
        return bookEndingPopupPrefab;
    }
}
