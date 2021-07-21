using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CharacterMaintenance_Skill_UIBar_InfoController : MonoBehaviour, IObserver<Information> {
    [SerializeField] Text SkillPointText = null;
    [SerializeField] Text SkillUIBarText = null;

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(Information value) {
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
