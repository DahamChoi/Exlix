using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsideAreaCharacterInfoDataController : MonoBehaviour {

    #region CharacterBasic
    [SerializeField] Image characterPortraitImage = null;
    [SerializeField] Text characterNameText = null;
    [SerializeField] Text characterLevelText = null;
    [SerializeField] Text characterHealthPointText = null;
    [SerializeField] Text characterManaPointText = null;
    #endregion

    #region CharacterStatus
    [SerializeField] Text statusText = null;
    [SerializeField] Text statusHealthText = null;
    [SerializeField] Text statusStrengthText = null;
    [SerializeField] Text statusAgilityText = null;
    [SerializeField] Text statusIntellectText = null;
    [SerializeField] Text statusHealthValue = null;
    [SerializeField] Text statusStrengthValue = null;
    [SerializeField] Text statusAgilityValue = null;
    [SerializeField] Text statusIntellectValue = null;
    #endregion

    #region CharacterSkill
    [SerializeField] Image skillImage = null;
    [SerializeField] Text skillText = null;
    [SerializeField] Text skillTitleText = null;
    [SerializeField] Text skillCooltimeText = null;
    [SerializeField] Text skillDescriptionText = null;
    #endregion

    #region CharacterEquipment
    [SerializeField] Text equipmentText = null;
    [SerializeField] Image equipmentHeadImage = null;
    [SerializeField] Text equipmentHeadPartsText = null;
    [SerializeField] Text equipmentHeadTitleText = null;
    [SerializeField] Text equipmentHeadDescriptionText = null;
    [SerializeField] Image equipmentUpperImage = null;
    [SerializeField] Text equipmentUpperPartsText = null;
    [SerializeField] Text equipmentUpperTitleText = null;
    [SerializeField] Text equipmentUpperDescriptionText = null;
    [SerializeField] Image equipmentUnderImage = null;
    [SerializeField] Text equipmentUnderPartsText = null;
    [SerializeField] Text equipmentUnderTitleText = null;
    [SerializeField] Text equipmentUnderDescriptionText = null;
    [SerializeField] Image equipmentWeaponImage = null;
    [SerializeField] Text equipmentWeaponPartsText = null;
    [SerializeField] Text equipmentWeaponTitleText = null;
    [SerializeField] Text equipmentWeaponDescriptionText = null;
    [SerializeField] Image equipmentAccessoryImage = null;
    [SerializeField] Text equipmentAccessoryPartsText = null;
    [SerializeField] Text equipmentAccessoryTitleText = null;
    [SerializeField] Text equipmentAccessoryDescriptionText = null;
    [SerializeField] Image equipmentOddmentsImage = null;
    [SerializeField] Text equipmentOddmentsPartsText = null;
    [SerializeField] Text equipmentOddmentsTitleText = null;
    [SerializeField] Text equipmentOddmentsDescriptionText = null;
    #endregion


    // Start is called before the first frame update
    void Start() {
        Init();
    }

    // Update is called once per frame
    void Update() {

    }

    void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        PortraitDTO portrait = PortraitDAO.SelectPortrait(characterInfo.Portrait);
        SkillDTO skillInfo = SkillDAO.GetSelectedSkillInfo(characterInfo.CurrentSkill);
        EquipmentDTO headEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentHead);
        EquipmentDTO upperEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUpperBody);
        EquipmentDTO underEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUnderBody);
        EquipmentDTO weaponEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentWeapon);
        EquipmentDTO accessoryEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentAccessory);
        EquipmentDTO oddmentsEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentPocket);
        
        characterPortraitImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
        characterNameText.text = $"{characterInfo.Name}";
        characterLevelText.text = $"{CommonDefineKR.LevelString} : {characterInfo.Level}";
        characterHealthPointText.text = $"{CommonDefineKR.HpString} : {characterInfo.Hp} / {characterInfo.Hp}";
        characterManaPointText.text = $"{CommonDefineKR.MpString} : {characterInfo.Mp}";

        statusText.text = $"{CommonDefineKR.StatusString}";
        statusHealthText.text = $"{CommonDefineKR.HpString}";
        statusStrengthText.text = $"{CommonDefineKR.StrengthString}";
        statusAgilityText.text = $"{CommonDefineKR.AgilityString}";
        statusIntellectText.text = $"{CommonDefineKR.IntellectString}";

        statusHealthValue.text = $"{characterInfo.StatHp}";
        statusStrengthValue.text = $"{characterInfo.StatStr}";
        statusAgilityValue.text = $"{characterInfo.StatDex}";
        statusIntellectValue.text = $"{characterInfo.StatInt}";

        skillText.text = $"{CommonDefineKR.SkillString}";

        skillImage.sprite = Resources.Load(skillInfo.ImagePath, typeof(Sprite)) as Sprite;
        skillTitleText.text = $"{skillInfo.Name}";
        skillCooltimeText.text = $"{CommonDefineKR.SkillCooltimeString} {CommonDefineKR.TurnString} : {skillInfo.CoolTime}{CommonDefineKR.TurnString}";
        skillDescriptionText.text = $"{skillInfo.Explain}";

        equipmentText.text = $"{CommonDefineKR.EquipmentString}";

        equipmentHeadImage.sprite = Resources.Load(headEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        equipmentHeadPartsText.text = $"{CommonDefineKR.HeadString}";
        equipmentHeadTitleText.text = $"{headEquipmentInfo.Name}";
        equipmentHeadDescriptionText.text = $"{headEquipmentInfo.Explain}";

        equipmentUpperImage.sprite = Resources.Load(upperEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        equipmentUpperPartsText.text = $"{CommonDefineKR.UpperString}";
        equipmentUpperTitleText.text = $"{upperEquipmentInfo.Name}";
        equipmentUpperDescriptionText.text = $"{upperEquipmentInfo.Explain}";

        equipmentUnderImage.sprite = Resources.Load(underEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        equipmentUnderPartsText.text = $"{CommonDefineKR.UnderString}";
        equipmentUnderTitleText.text = $"{underEquipmentInfo.Name}";
        equipmentUnderDescriptionText.text = $"{underEquipmentInfo.Explain}";

        equipmentWeaponImage.sprite = Resources.Load(weaponEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        equipmentWeaponPartsText.text = $"{CommonDefineKR.WeaponString}";
        equipmentWeaponTitleText.text = $"{weaponEquipmentInfo.Name}";
        equipmentWeaponDescriptionText.text = $"{weaponEquipmentInfo.Explain}";

        equipmentAccessoryImage.sprite = Resources.Load(accessoryEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        equipmentAccessoryPartsText.text = $"{CommonDefineKR.AccessoryString}";
        equipmentAccessoryTitleText.text = $"{accessoryEquipmentInfo.Name}";
        equipmentAccessoryDescriptionText.text = $"{accessoryEquipmentInfo.Explain}";

        equipmentOddmentsImage.sprite = Resources.Load(oddmentsEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        equipmentOddmentsPartsText.text = $"{CommonDefineKR.OddmentsString}";
        equipmentOddmentsTitleText.text = $"{oddmentsEquipmentInfo.Name}";
        equipmentOddmentsDescriptionText.text = $"{oddmentsEquipmentInfo.Explain}";
    }
}
