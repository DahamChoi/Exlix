using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarInfoController : MonoBehaviour {
    // Area
    [SerializeField] Text PlayerNameText = null;
    [SerializeField] Text PlayerLevelText = null;
    [SerializeField] Text PlayerHpText = null;
    [SerializeField] Text PlayerMpText = null;
    [SerializeField] Text StageNameText = null;
    [SerializeField] Image PlayerIconImage = null;

    // Skill
    [SerializeField] Text ContainSkillPointText = null;

    // Gold
    [SerializeField] Text CoinText = null;

    void Start() {
        Init();
    }

    private void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        PlayerNameText.text = characterInfo.Name;
        PlayerLevelText.text = $"{CommonDefineKR.LevelString} {characterInfo.Level}";
        PlayerHpText.text = $"{CommonDefineKR.HpString} {characterInfo.Hp}";
        PlayerMpText.text = $"{CommonDefineKR.MpString} {characterInfo.Mp}";

        AreaDTO area = AreaDAO.SelectArea(characterInfo.CurrentArea);
        if (null != area) {
            StageNameText.text = area.Name;
        }

        PortraitDTO portrait = PortraitDAO.SelectPortrait(characterInfo.Portrait);
        PlayerIconImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;

        ContainSkillPointText.text = $"{CommonDefineKR.ContainSkillPointString} {characterInfo.SkillPoint}";

        CoinText.text = characterInfo.Gold.ToString();
    }
}
