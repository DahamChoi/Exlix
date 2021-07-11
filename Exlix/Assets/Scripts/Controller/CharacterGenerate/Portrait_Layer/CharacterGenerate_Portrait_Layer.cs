﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerate_Portrait_Layer : MonoBehaviour {
    [SerializeField] PlayerState _PlayerState;
    [SerializeField] CharacterGenerate_Portrait_UIController _UIController;

    [SerializeField] GameObject popup;
    public void Start() {
        Init();
    }
    private void Init() {
        FactoryManager.GetInstance().CreatePortraitObject(popup.transform);
    }
}
