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

    [SerializeField] Text ContainSkillPointText = null;

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
    public void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        PlayerNameText.text = characterInfo.Name;
        PlayerLevelText.text = $"{CommonDefineKR.LevelString} {characterInfo.Level}";
        PlayerHpText.text = $"{CommonDefineKR.HpString} {characterInfo.Hp}";
        PlayerMpText.text = $"{CommonDefineKR.MpString} {characterInfo.Mp}";

        PlayerStatHpText.text = $"{characterInfo.StatHp}";
        PlayerStatStrText.text = $"{characterInfo.StatStr}";
        PlayerStatDexText.text =  $"{characterInfo.StatDex}";
        PlayerStatIntText.text = $"{characterInfo.StatInt}";

        PortraitDTO portrait = PortraitDAO.SelectPortrait(characterInfo.Portrait);
        PlayerIconImage.sprite = Resources.Load(portrait.ImagePath, typeof(Sprite)) as Sprite;
        ContainSkillPointText.text = $"{CommonDefineKR.ContainSkillPointString} {characterInfo.SkillPoint}";

        SkillDTO skill = SkillDAO.GetSelectedSkillInfo(characterInfo.CurrentSkill);
        CurrentSkillNameText.text = skill.Name;
        CurrentSkillDescribeText.text = skill.Explain;
        CurrentSkillIconImage.sprite = Resources.Load(skill.ImagePath, typeof(Sprite)) as Sprite;
        CurrentSkillChargeText.text = $"{CommonDefineKR.SkillCooltimeString} {" : "} {skill.CoolTime} {CommonDefineKR.TurnString}";

        EquipmentDTO equipHead = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentHead);
        EquipmentDTO equipUpperBody = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUpperBody);
        EquipmentDTO equipUnderBody = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUnderBody);
        EquipmentDTO equipWeapon = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentWeapon);
        EquipmentDTO equipAccessory = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentAccessory);
        EquipmentDTO equipPocket = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentPocket);

        CurrentEquipmentHeadIconImage.sprite = Resources.Load(equipHead.ImagePath,typeof(Sprite)) as Sprite;
        CurrentEquipmentUpperBodyIconImage.sprite = Resources.Load(equipUpperBody.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentUnderBodyImage.sprite = Resources.Load(equipUnderBody.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentWeaponIconImage.sprite = Resources.Load(equipWeapon.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentAccessoryIconImage.sprite = Resources.Load(equipAccessory.ImagePath, typeof(Sprite)) as Sprite;
        CurrentEquipmentPocketIconImage.sprite = Resources.Load(equipPocket.ImagePath, typeof(Sprite)) as Sprite;
    }
}
