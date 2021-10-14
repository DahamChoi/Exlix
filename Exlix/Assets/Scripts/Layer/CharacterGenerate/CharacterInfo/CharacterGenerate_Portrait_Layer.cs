using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerate_Portrait_Layer : MonoBehaviour {
    [SerializeField] GameObject popup = null;
    List<PortraitObject> PortraitList = null;
    public void Start() {
        Init();
    }
    private void Init() {
        List<PortraitObject> portraitObjectList = new List<PortraitObject>();
        List<Portrait> portraitData = PortraitDao.GetPortraitList();

        GameObject portraitPrefab = Resources.Load("Prefabs/Portrait") as GameObject;

        for (int i = 0; i < portraitData.Count; i++) {
            GameObject portraitObject = Instantiate<GameObject>(portraitPrefab, popup.transform);
            portraitObject.transform.SetParent(popup.transform);
            portraitObject.GetComponent<PortraitObject>().init(portraitData[i]);
        }
    
       PortraitList = portraitObjectList;
    }
}
