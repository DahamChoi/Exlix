using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : Singleton<FactoryManager> {
    [SerializeField] PortraitObject PortraitObjectPrefab;

    public GameObject CreateCardObject(int cardId, Transform parent) {
        GameObject cardObjectPrefab = Resources.Load("Prefabs/CardObject") as GameObject;
        GameObject cardObject = Instantiate<GameObject>(cardObjectPrefab, parent);
        CardDTO cardData = CardDAO.SelectCard(cardId);
        cardObject.GetComponent<CardObject>().init(cardData);
        return cardObject;
    }

    public List<PortraitObject> CreatePortraitObject(Transform parent) {
        List<PortraitObject> portraitObjectList = new List<PortraitObject>();
        List<PortraitDTO> portraitData = PortraitDAO.SelectAllPortrait();

        for (int i = 0; i < portraitData.Count; i++) {
            Debug.Log(portraitData[i].Number);
            PortraitObject portraitObject = Instantiate<PortraitObject>(PortraitObjectPrefab, parent);
            portraitObject.transform.parent = parent;
            portraitObject.init(portraitData[i]);

            portraitObjectList.Add(portraitObject);
        }
        return portraitObjectList;
    }

    public GameObject CreateSelectAreaPopup(AreaDTO areaDTO, Transform parent) {
        GameObject selectAreaPopupPrefab = Resources.Load("Prefabs/SelectAreaPopup") as GameObject;
        GameObject selectAreaPopup = Instantiate<GameObject>(selectAreaPopupPrefab, parent);
        selectAreaPopup.GetComponent<SelectAreaPopup>().Init(areaDTO);
        return selectAreaPopup;
    }
}
