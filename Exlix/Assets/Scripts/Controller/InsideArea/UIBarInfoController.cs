﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarInfoController : MonoBehaviour {
    // Area
    [SerializeField] Text PlayerNameText;
    [SerializeField] Text PlayerLevelText;
    [SerializeField] Text PlayerHpText;
    [SerializeField] Text PlayerMpText;
    [SerializeField] Text StageNameText;
    [SerializeField] Image PlayerIconImage;

    // Skill
    [SerializeField] Text ContainSkillPointText;

    // Gold
    [SerializeField] Text CoinText;

    // SQLiteManager
    [SerializeField] SQLiteManager _SQLiteManager;

    void Start() {
        Init();
    }

    private void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo(_SQLiteManager);
        PlayerNameText.text = characterInfo.Name;
        PlayerLevelText.text = $"{CommonDefine.LevelString} {characterInfo.Level}";
        PlayerHpText.text = $"{CommonDefine.HpString} {characterInfo.Hp}";
        PlayerMpText.text = $"{CommonDefine.MpString} {characterInfo.Mp}";
        StageNameText.text = characterInfo.CurrentArea;

        PortraitDTO portrait = PortraitDAO.SelectPortrait(_SQLiteManager, characterInfo.Portrait);
        PlayerIconImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;

        ContainSkillPointText.text = $"{CommonDefine.ContainSkillPointKR} {characterInfo.SkillPoint}";

        CoinText.text = characterInfo.Gold.ToString();
    }
}
