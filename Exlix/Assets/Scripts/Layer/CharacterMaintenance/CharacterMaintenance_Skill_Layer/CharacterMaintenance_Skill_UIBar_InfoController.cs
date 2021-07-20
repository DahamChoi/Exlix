﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterMaintenance_Skill_UIBar_InfoController : MonoBehaviour, IObserver<SceneState> {
    [SerializeField] Text SkillPointText;
    [SerializeField] Text SkillUIBarText;

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(SceneState value) {
        Init();
    }

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update() {

    }

    void Init() {
        SkillPointText.text = $"{CommonDefineKR.LeftSkillPointString} : {CharacterInfoDAO.GetCharacterInfo().SkillPoint}";
        SkillUIBarText.text = $"{CommonDefineKR.SkillString}";
    }
}
