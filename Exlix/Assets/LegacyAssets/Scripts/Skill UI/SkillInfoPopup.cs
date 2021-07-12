using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillInfoPopup : MonoBehaviour
{
    [SerializeField] GameObject unEquipButton;
    [SerializeField] GameObject equipButton;
    [SerializeField] GameObject unlockButton;
    [SerializeField] GameObject disabledButton;
    [SerializeField] Text title;
    [SerializeField] Text explain;
    [SerializeField] GameState _GameState;
    [SerializeField] PlayerState _PlayerState;
    
    SkillDataTemplate skillData;
    SkillNode skillNode;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // 스킬 정보 팝업 활성화
    public void PopupActive(SkillNode data) {
        skillNode = data;
        GetSkillData();
        TextChanger();
        ButtonChanger();
        gameObject.SetActive(true);
    }

    void GetSkillData() {
        skillData = _GameState._GameStateInfoHandler.GetSkillDataTamplate(skillNode.skillId.ToString());
    }

    void ButtonChanger() {
        unEquipButton.SetActive(false);
        equipButton.SetActive(false);
        unlockButton.SetActive(false);
        disabledButton.SetActive(false);
        if (skillNode.pSkill.isActivated == false) disabledButton.SetActive(true);
        else if (skillNode.isActivated == false) unlockButton.SetActive(true);
        else if (_PlayerState._PlayerStateInfoHandler.GetCurrentSkill().GetSkillData("Number") == skillNode.skillId.ToString()) unEquipButton.SetActive(true);
        else equipButton.SetActive(true);
    }

    void TextChanger() {
        title.text = skillData.Data["Title"];
        title.text = skillData.Data["Explanation"];
    }

    // 스킬 활성화
    public void SkillEquip() {
        _PlayerState._PlayerStateInfoHandler.SetCurrentSkill(skillData);
        ButtonChanger();
    }
    
    public void SkillUnequip() {
        _PlayerState._PlayerStateInfoHandler.SetCurrentSkill(null);
        ButtonChanger();
    }

    public void SkillUnlock() {
        _PlayerState._PlayerStateInfoHandler.UnlockSkill(skillNode.skillId, 0);
        ButtonChanger();
    }

    // 스킬 정보 팝업 비활성화
    public void PopupDeactive() {
        gameObject.SetActive(false);
    }

}
