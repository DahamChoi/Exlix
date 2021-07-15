using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerate_Portrait_Layer : MonoBehaviour {
    [SerializeField] PlayerState _PlayerState = null;
    [SerializeField] GameObject popup = null;
    public void Start() {
        Init();
    }
    private void Init() {
       FactoryManager.GetInstance().CreatePortraitObject(popup.transform);
    }
}
