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
       PortraitList = FactoryManager.GetInstance().CreatePortraitObject(popup.transform);
    }
}
