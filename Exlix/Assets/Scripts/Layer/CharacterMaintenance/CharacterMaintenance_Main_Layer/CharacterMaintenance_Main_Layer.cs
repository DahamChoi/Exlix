using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMaintenance_Main_Layer : MonoBehaviour {
    [SerializeField] Text playerNameText = null;
    [SerializeField] Text playerLevelText = null;
    [SerializeField] Text playerHpText = null;
    [SerializeField] Text playerMpText = null;

    [SerializeField] Text playerStatHpText = null;
    [SerializeField] Text playerStatStrText = null;
    [SerializeField] Text playerStatDexText = null;
    [SerializeField] Text playerStatIntText = null;

    [SerializeField] Image playerIconImage = null;

    [SerializeField] Text containStatPointText = null;

    [SerializeField] Text currentSkillNameText = null;
    [SerializeField] Text currentSkillDescribeText = null;
    [SerializeField] Image currentSkillIconImage = null;
    [SerializeField] Text currentSkillChargeText = null;

    [SerializeField] Image currentEquipmentHeadIconImage = null;
    [SerializeField] Image currentEquipmentUpperBodyIconImage = null;
    [SerializeField] Image currentEquipmentUnderBodyImage = null;
    [SerializeField] Image currentEquipmentWeaponIconImage = null;
    [SerializeField] Image currentEquipmentAccessoryIconImage = null;
    [SerializeField] Image currentEquipmentPocketIconImage = null;

    [SerializeField] GameObject skillNotice = null;
    [SerializeField] GameObject equipNotice = null;

    [SerializeField] Button hpAddButton = null;
    [SerializeField] Button hpSubButton = null;
    [SerializeField] Button strAddButton = null;
    [SerializeField] Button strSubButton = null;
    [SerializeField] Button dexAddButton = null;
    [SerializeField] Button dexSubButton = null;
    [SerializeField] Button intAddButton = null;
    [SerializeField] Button intSubButton = null;
    [SerializeField] Button startButton = null;

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
        InitButton();
    }
    private void OnEnable() {
        Init();
        DrawUI();
    }

    void InitButton() {
        startButton.onClick.AddListener(() => {
            CharacterInfoDAO.UpdatePlayerInfo(characterInfo);
        });

        hpAddButton.onClick.AddListener(() => {
            AddStat("HP", playerStatHpText);
            DrawUI();
        });

        hpSubButton.onClick.AddListener(() => {
            SubStat("HP", playerStatHpText);
            DrawUI();
        });

        strAddButton.onClick.AddListener(() => {
            AddStat("STR", playerStatStrText);
            DrawUI();
        });

        strSubButton.onClick.AddListener(() => {
            SubStat("STR", playerStatStrText);
            DrawUI();
        });

        dexAddButton.onClick.AddListener(() => {
            AddStat("DEX", playerStatDexText);
            DrawUI();
        });

        dexSubButton.onClick.AddListener(() => {
            SubStat("DEX", playerStatDexText);
            DrawUI();
        });

        intAddButton.onClick.AddListener(() => {
            AddStat("INT", playerStatIntText);
            DrawUI();
        });

        intSubButton.onClick.AddListener(() => {
            SubStat("INT", playerStatIntText);
            DrawUI();
        });
    }

    public void Init() {//캐릭터 데이터 초기화
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

    public void DrawUI() {//화면에 그려지는 UI의 text와 image를 새로운 정보로 갱신 
        playerNameText.text = characterInfo.Name;
        playerLevelText.text = $"{CommonDefineKR.LevelString} : {characterInfo.Level}";
        playerHpText.text = $"{CommonDefineKR.HpString} : {characterInfo.CurrentHp} / {characterInfo.Hp}";
        playerMpText.text = $"{CommonDefineKR.MpString} : {characterInfo.Mp}";

        playerStatHpText.text = $"{characterInfo.StatHp}";
        playerStatStrText.text = $"{characterInfo.StatStr}";
        playerStatDexText.text = $"{characterInfo.StatDex}";
        playerStatIntText.text = $"{characterInfo.StatInt}";

        playerIconImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
        containStatPointText.text = $"{CommonDefineKR.ContainSkillPointString} {characterInfo.StatPoint}";

        currentSkillNameText.text = skill.Name;
        currentSkillDescribeText.text = skill.Explain;
        currentSkillIconImage.sprite = Resources.Load(skill.ImagePath, typeof(Sprite)) as Sprite;
        currentSkillChargeText.text = $"{CommonDefineKR.SkillCooltimeString} : {skill.CoolTime} {CommonDefineKR.TurnString}";

        currentEquipmentHeadIconImage.sprite = Resources.Load(equipHead.ImagePath, typeof(Sprite)) as Sprite;
        currentEquipmentUpperBodyIconImage.sprite = Resources.Load(equipUpperBody.ImagePath, typeof(Sprite)) as Sprite;
        currentEquipmentUnderBodyImage.sprite = Resources.Load(equipUnderBody.ImagePath, typeof(Sprite)) as Sprite;
        currentEquipmentWeaponIconImage.sprite = Resources.Load(equipWeapon.ImagePath, typeof(Sprite)) as Sprite;
        currentEquipmentAccessoryIconImage.sprite = Resources.Load(equipAccessory.ImagePath, typeof(Sprite)) as Sprite;
        currentEquipmentPocketIconImage.sprite = Resources.Load(equipPocket.ImagePath, typeof(Sprite)) as Sprite;

        if (characterInfo.SkillPoint >0) {
            skillNotice.SetActive(true);
        }
        else {
            skillNotice.SetActive(false);
        }

    }

    public void AddStat(string statType, Text statText) {//스테이터스 버튼 기능(스탯 추가)
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
            containStatPointText.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
        }
    }

    public void SubStat(string statType, Text statText) {//스테이터스 버튼 기능(스탯 감소)
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
            containStatPointText.text = $"{"잔여 포인트 :"} {characterInfo.StatPoint}";
        }
    }

}
