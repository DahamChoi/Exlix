using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerate_Portrait_Layer : MonoBehaviour
{
    [SerializeField] FactoryManager _FactoryManager;
    [SerializeField] CharacterGenerate_Portrait_UIController _UIController;

    [SerializeField] GameObject popup;
    public void Start() {
        Init();
    }
    private void Init() {
        _FactoryManager.CreatePortraitObject(1, popup.transform);
        _FactoryManager.CreatePortraitObject(2, popup.transform);
        _FactoryManager.CreatePortraitObject(3, popup.transform);
        _FactoryManager.CreatePortraitObject(4, popup.transform);
        _FactoryManager.CreatePortraitObject(5, popup.transform);
        _FactoryManager.CreatePortraitObject(6, popup.transform);
        _FactoryManager.CreatePortraitObject(7, popup.transform);
        _FactoryManager.CreatePortraitObject(8, popup.transform);
        _FactoryManager.CreatePortraitObject(9, popup.transform);
        _FactoryManager.CreatePortraitObject(10, popup.transform);
        _FactoryManager.CreatePortraitObject(11, popup.transform);
        _FactoryManager.CreatePortraitObject(12, popup.transform);
    }
}
