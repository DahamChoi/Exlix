using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelectInfoController : MonoBehaviour {
    [SerializeField] Image headEquipmentSlotImage = null;
    [SerializeField] Image upperEquipmentSlotImage = null;
    [SerializeField] Image underEquipmentSlotImage = null;
    [SerializeField] Image weaponEquipmentSlotImage = null;
    [SerializeField] Image accessoryEquipmentSlotImage = null;
    [SerializeField] Image oddmentEquipmentSlotImage = null;
    [SerializeField] Image headEquipmentListImage = null;
    [SerializeField] Image upperEquipmentListImage = null;
    [SerializeField] Image underEquipmentListImage = null;
    [SerializeField] Image weaponEquipmentListImage = null;
    [SerializeField] Image accessoryEquipmentListImage = null;
    [SerializeField] Image oddmentEquipmentListImage = null;
    [SerializeField] Text headEquipmentPart = null;
    [SerializeField] Text headEquipmentTitle = null;
    [SerializeField] Text headEquipmentDescription = null;
    [SerializeField] Text upperEquipmentPart = null;
    [SerializeField] Text upperEquipmentTitle = null;
    [SerializeField] Text upperEquipmentDescription = null;
    [SerializeField] Text underEquipmentPart = null;
    [SerializeField] Text underEquipmentTitle = null;
    [SerializeField] Text underEquipmentDescription = null;
    [SerializeField] Text weaponEquipmentPart = null;
    [SerializeField] Text weaponEquipmentTitle = null;
    [SerializeField] Text weaponEquipmentDescription = null;
    [SerializeField] Text accessoryEquipmentPart = null;
    [SerializeField] Text accessoryEquipmentTitle = null;
    [SerializeField] Text accessoryEquipmentDescription = null;
    [SerializeField] Text oddmentEquipmentPart = null;
    [SerializeField] Text oddmentEquipmentTitle = null;
    [SerializeField] Text oddmentEquipmentDescription = null;

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        EquipmentDTO headEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentHead);
        EquipmentDTO upperEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUpperBody);
        EquipmentDTO underEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentUnderBody);
        EquipmentDTO weaponEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentWeapon);
        EquipmentDTO accessoryEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentAccessory);
        EquipmentDTO oddmentsEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentPocket);

        headEquipmentSlotImage.sprite = Resources.Load(headEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        upperEquipmentSlotImage.sprite = Resources.Load(upperEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        underEquipmentSlotImage.sprite = Resources.Load(underEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        weaponEquipmentSlotImage.sprite = Resources.Load(weaponEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        accessoryEquipmentSlotImage.sprite = Resources.Load(accessoryEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        oddmentEquipmentSlotImage.sprite = Resources.Load(oddmentsEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;

        headEquipmentListImage.sprite = Resources.Load(headEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        headEquipmentPart.text = $"{CommonDefineKR.HeadString}";
        headEquipmentTitle.text = $"{headEquipmentInfo.Name}";
        headEquipmentDescription.text = $"{headEquipmentInfo.Explain}";

        upperEquipmentListImage.sprite = Resources.Load(upperEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        upperEquipmentPart.text = $"{CommonDefineKR.UpperString}";
        upperEquipmentTitle.text = $"{upperEquipmentInfo.Name}";
        upperEquipmentDescription.text = $"{upperEquipmentInfo.Explain}";

        underEquipmentListImage.sprite = Resources.Load(underEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        underEquipmentPart.text = $"{CommonDefineKR.UnderString}";
        underEquipmentTitle.text = $"{underEquipmentInfo.Name}";
        underEquipmentDescription.text = $"{underEquipmentInfo.Explain}";

        weaponEquipmentListImage.sprite = Resources.Load(weaponEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        weaponEquipmentPart.text = $"{CommonDefineKR.WeaponString}";
        weaponEquipmentTitle.text = $"{weaponEquipmentInfo.Name}";
        weaponEquipmentDescription.text = $"{weaponEquipmentInfo.Explain}";

        accessoryEquipmentListImage.sprite = Resources.Load(accessoryEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        accessoryEquipmentPart.text = $"{CommonDefineKR.AccessoryString}";
        accessoryEquipmentTitle.text = $"{accessoryEquipmentInfo.Name}";
        accessoryEquipmentDescription.text = $"{accessoryEquipmentInfo.Explain}";

        oddmentEquipmentListImage.sprite = Resources.Load(oddmentsEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        oddmentEquipmentPart.text = $"{CommonDefineKR.OddmentsString}";
        oddmentEquipmentTitle.text = $"{oddmentsEquipmentInfo.Name}";
        oddmentEquipmentDescription.text = $"{oddmentsEquipmentInfo.Explain}";
    }
}
