using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMaintenance_Main_Layer : MonoBehaviour
{
    [SerializeField] Text PlayerNameText = null;
    [SerializeField] Text PlayerLevelText = null;
    [SerializeField] Text PlayerHpText = null;
    [SerializeField] Text PlayerMpText = null;

    [SerializeField] Text PlayerStatHpText = null;
    [SerializeField] Text PlayerStatStrText = null;
    [SerializeField] Text PlayerStatDexText = null;
    [SerializeField] Text PlayerStatIntText = null;

    [SerializeField] Image PlayerIconImage = null;

    [SerializeField] Text ContainStatPointText = null;

    [SerializeField] Text CurrentSkillNameText = null;
    [SerializeField] Text CurrentSkillDescribeText = null;
    [SerializeField] Image CurrentSkillIconImage = null;
    [SerializeField] Text CurrentSkillChargeText = null;

    [SerializeField] Image CurrentEquipmentHeadIconImage = null;
    [SerializeField] Image CurrentEquipmentUpperBodyIconImage = null;
    [SerializeField] Image CurrentEquipmentUnderBodyImage = null;
    [SerializeField] Image CurrentEquipmentWeaponIconImage = null;
    [SerializeField] Image CurrentEquipmentAccessoryIconImage = null;
    [SerializeField] Image CurrentEquipmentPocketIconImage = null;

    [SerializeField] Button HpAddButton = null;
    [SerializeField] Button HpSubButton = null;
    [SerializeField] Button StrAddButton = null;
    [SerializeField] Button StrSubButton = null;
    [SerializeField] Button DexAddButton = null;
    [SerializeField] Button DexSubButton = null;
    [SerializeField] Button IntAddButton = null;
    [SerializeField] Button IntSubButton = null;
    [SerializeField] Button StartButton = null;


    CharacterInfoDTO characterInfo;
    CharacterInfoDTO characterInfo_Original;
    SkillDTO skill;
    PortraitDTO portrait;
    EquipmentDTO equipHead;
    EquipmentDTO equipUpperBody;
    EquipmentDTO equipUnderBody;
    EquipmentDTO equipWeapon;
    EquipmentDTO equipAccessory;
    EquipmentDTO equipPocket;

    private void Start() {
        StartButton.onClick.AddListener(() => {
            CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
        });

        HpAddButton.onClick.AddListener(() => {
            AddStat("HP", PlayerStatHpText);
            DrawUI();
        });

        HpSubButton.onClick.AddListener(() => {
            SubStat("HP", PlayerStatHpText);
            DrawUI();
        });

        StrAddButton.onClick.AddListener(() => {
            AddStat("STR", PlayerStatStrText);
            DrawUI();
        });

        StrSubButton.onClick.AddListener(() => {
            SubStat("STR", PlayerStatStrText);
            DrawUI();
        });

        DexAddButton.onClick.AddListener(() => {
            AddStat("DEX", PlayerStatDexText);
            DrawUI();
        });

        DexSubButton.onClick.AddListener(() => {
            SubStat("DEX", PlayerStatDexText);
            DrawUI();
        });

        IntAddButton.onClick.AddListener(() => {
            AddStat("INT", PlayerStatIntText);
            DrawUI();
        });

        IntSubButton.onClick.AddListener(() => {
            SubStat("INT", PlayerStatIntText);
            DrawUI();
        });
    }
    private void OnEnable() {
        Init();
        DrawUI();
    }

    public void Init() {
        characterInfo = CharacterInfoDAO.GetCharacterInfo();
        characterInfo_Original = CharacterInfoDAO.GetCharacterInfo();
        portrait = PortraitDAO.SelectPortrait(characterInfo.Portrait);
        skill = SkillDAO.GetSelectedSkillInfo(characterInfo.CurrentSkill);
        equipHead = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentHead);
        equipUpperBody = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUpperBody);
        equipUnderBody = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUnderBody);
        equipWeapon = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentWeapon);
        equipAccessory = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentAccessory);
        equipPocket = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentPocket); 
    }

    public void DrawUI() {
        PlayerNameText.text = characterInfo.Name;
        PlayerLevelText.text = $"{CommonDefineKR.LevelString} : {characterInfo.Level}";
        PlayerHpText.text = $"{CommonDefineKR.HpString} : {characterInfo.CurrentHp} / {characterInfo.Hp}";
        PlayerMpText.text = $"{CommonDefineKR.MpString} : {characterInfo.Mp}";

        PlayerStatHpText.text = $"{characterInfo.StatHp}";
        PlayerStatStrText.text = $"{characterInfo.StatStr}";
        PlayerStatDexText.text = $"{characterInfo.StatDex}";
        PlayerStatIntText.text = $"{characterInfo.StatInt}";

        PlayerIconImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
        ContainStatPointText.text = $"{CommonDefineKR.ContainSkillPointString} {characterInfo.StatPoint}";

        CurrentSkillNameText.text = skill.Name;
        CurrentSkillDescribeText.text = skill.Explain;
        CurrentSkillIconImage.sprite = Resources.Load(skill.ImagePath, typeof(Sprite)) as Sprite;
        CurrentSkillChargeText.text = $"{CommonDefineKR.SkillCooltimeString} : {skill.CoolTime} {CommonDefineKR.TurnString}";

        CurrentEquipmentHeadIconImage.sprite = Resources.Load(equipHead.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentUpperBodyIconImage.sprite = Resources.Load(equipUpperBody.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentUnderBodyImage.sprite = Resources.Load(equipUnderBody.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentWeaponIconImage.sprite = Resources.Load(equipWeapon.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentAccessoryIconImage.sprite = Resources.Load(equipAccessory.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentPocketIconImage.sprite = Resources.Load(equipPocket.ImagePath, typeof(Sprite)) as Sprite;
    }

    public void AddStat(string statType, Text statText) {
        if (characterInfo.StatPoint > 0) {
            switch (statType) {
                case "HP"://HP
                    characterInfo.StatHp++;
                    characterInfo.StatPoint--;
                    characterInfo.Hp = characterInfo.StatHp * 10;
                    statText.text = $"{characterInfo.StatHp}";
                    break;
                case "STR"://STR
                    characterInfo.StatStr++;
                    characterInfo.StatPoint--;
                    statText.text = $"{characterInfo.StatStr}";
                    break;
                case "INT"://INT
                    characterInfo.StatInt++;
                    characterInfo.StatPoint--;
                    statText.text = $"{characterInfo.StatInt}";
                    break;
                case "DEX"://DEX
                    characterInfo.StatDex++;
                    characterInfo.StatPoint--;
                    statText.text = $"{characterInfo.StatDex}";
                    break;
                default:
                    break;
            }
            ContainStatPointText.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
        }
    }

    public void SubStat(string statType, Text statText) {
        if (characterInfo.StatPoint < characterInfo_Original.StatPoint) {
            switch (statType) {
                case "HP"://HP
                    if (characterInfo.StatHp > characterInfo_Original.StatHp) {
                        characterInfo.StatHp--;
                        characterInfo.StatPoint++;
                        characterInfo.Hp = characterInfo.StatHp * 10;
                        characterInfo.CurrentHp = characterInfo.StatHp * 10;
                        statText.text = $"{characterInfo.StatHp}";
                    }
                    break;
                case "STR"://STR
                    if (characterInfo.StatStr > characterInfo_Original.StatStr) {
                        characterInfo.StatStr--;
                        characterInfo.StatPoint++;
                        statText.text = $"{characterInfo.StatStr}";
                    }
                    break;
                case "INT"://INT
                    if (characterInfo.StatInt > characterInfo_Original.StatInt) {
                        characterInfo.StatInt--;
                        characterInfo.StatPoint++;
                        statText.text = $"{characterInfo.StatInt}";
                    }
                    break;
                case "DEX"://DEX
                    if (characterInfo.StatDex > characterInfo_Original.StatDex) {
                        characterInfo.StatDex--;
                        characterInfo.StatPoint++;
                        statText.text = $"{characterInfo.StatDex}";
                    }
                    break;
                default:
                    break;
            }
            ContainStatPointText.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
        }
    }

}
