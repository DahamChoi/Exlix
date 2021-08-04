using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIBarInfoController : MonoBehaviour, IObserver<UIStateInfo> {
    // Area
    [SerializeField] Text playerNameText = null;
    [SerializeField] Text playerLevelText = null;
    [SerializeField] Text playerHpText = null;
    [SerializeField] Text playerMpText = null;
    [SerializeField] Text stageNameText = null;
    [SerializeField] Image playerIconImage = null;

    // Skill
    [SerializeField] Text containSkillPointText = null;

    // Gold
    [SerializeField] Text coinText = null;

    void Start() {
        Init();
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();
    }

    private void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        playerNameText.text = characterInfo.Name;
        playerLevelText.text = $"{CommonDefineKR.LevelString} {characterInfo.Level}";
        playerHpText.text = $"{CommonDefineKR.HpString} {characterInfo.Hp}";
        playerMpText.text = $"{CommonDefineKR.MpString} {characterInfo.Mp}";

        AreaDTO area = AreaDAO.SelectArea(characterInfo.CurrentArea);
        if (null != area) {
            stageNameText.text = area.Name;
        }

        PortraitDTO portrait = PortraitDAO.SelectPortrait(characterInfo.Portrait);
        playerIconImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;

        containSkillPointText.text = $"{CommonDefineKR.ContainSkillPointString} {characterInfo.SkillPoint}";

        coinText.text = characterInfo.Gold.ToString();
    }
    public void OnNext(UIStateInfo value) {
        Init();
    }
    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }
}
