using System.Collections;
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

    void Start() {
        Init();
    }

    private void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        PlayerNameText.text = characterInfo.Name;
        PlayerLevelText.text = $"{CommonDefine.LevelString} {characterInfo.Level}";
        PlayerHpText.text = $"{CommonDefine.HpString} {characterInfo.Hp}";
        PlayerMpText.text = $"{CommonDefine.MpString} {characterInfo.Mp}";

        AreaDTO area = AreaDAO.SelectArea(characterInfo.CurrentArea);
        if (null != area) {
            StageNameText.text = area.Name;
        }

        PortraitDTO portrait = PortraitDAO.SelectPortrait(characterInfo.Portrait);
        PlayerIconImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;

        ContainSkillPointText.text = $"{CommonDefine.ContainSkillPointKR} {characterInfo.SkillPoint}";

        CoinText.text = characterInfo.Gold.ToString();
    }
}
