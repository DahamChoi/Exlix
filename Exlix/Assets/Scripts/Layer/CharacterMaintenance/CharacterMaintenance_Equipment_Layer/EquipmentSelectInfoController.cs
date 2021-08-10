using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelectInfoController : MonoBehaviour {
    [SerializeField] Image headEquipmentSlotImage = null;
    [SerializeField] Image shirtEquipmentSlotImage = null;
    [SerializeField] Image pantsEquipmentSlotImage = null;
    [SerializeField] Image weaponEquipmentSlotImage = null;
    [SerializeField] Image trinketEquipmentSlotImage = null;
    [SerializeField] Image etcEquipmentSlotImage = null;
    [SerializeField] Image headEquipmentListImage = null;
    [SerializeField] Image shirtEquipmentListImage = null;
    [SerializeField] Image pantsEquipmentListImage = null;
    [SerializeField] Image weaponEquipmentListImage = null;
    [SerializeField] Image trinketEquipmentListImage = null;
    [SerializeField] Image etcEquipmentListImage = null;
    [SerializeField] Text headEquipmentPart = null;
    [SerializeField] Text headEquipmentTitle = null;
    [SerializeField] Text headEquipmentDescription = null;
    [SerializeField] Text shirtEquipmentPart = null;
    [SerializeField] Text shirtEquipmentTitle = null;
    [SerializeField] Text shirtEquipmentDescription = null;
    [SerializeField] Text pantsEquipmentPart = null;
    [SerializeField] Text pantsEquipmentTitle = null;
    [SerializeField] Text pantsEquipmentDescription = null;
    [SerializeField] Text weaponEquipmentPart = null;
    [SerializeField] Text weaponEquipmentTitle = null;
    [SerializeField] Text weaponEquipmentDescription = null;
    [SerializeField] Text trinketEquipmentPart = null;
    [SerializeField] Text trinketEquipmentTitle = null;
    [SerializeField] Text trinketEquipmentDescription = null;
    [SerializeField] Text etcEquipmentPart = null;
    [SerializeField] Text etcEquipmentTitle = null;
    [SerializeField] Text etcEquipmentDescription = null;

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    void Init() {
        CharacterInfoDTO characterInfo = CharacterInfoDAO.GetCharacterInfo();
        EquipmentDTO headEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentHead);
        EquipmentDTO upperEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentShirt);
        EquipmentDTO underEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentPants);
        EquipmentDTO weaponEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentWeapon);
        EquipmentDTO accessoryEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentTrinket);
        EquipmentDTO oddmentsEquipmentInfo = EquipmentDAO.GetSelectedEquipmentInfo(characterInfo.CurrentEquipmentEtc);

        headEquipmentSlotImage.sprite = Resources.Load(headEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        shirtEquipmentSlotImage.sprite = Resources.Load(upperEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        pantsEquipmentSlotImage.sprite = Resources.Load(underEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        weaponEquipmentSlotImage.sprite = Resources.Load(weaponEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        trinketEquipmentSlotImage.sprite = Resources.Load(accessoryEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        etcEquipmentSlotImage.sprite = Resources.Load(oddmentsEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;

        headEquipmentListImage.sprite = Resources.Load(headEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        headEquipmentPart.text = $"{CommonDefineKR.HeadString}";
        headEquipmentTitle.text = $"{headEquipmentInfo.Name}";
        headEquipmentDescription.text = $"{headEquipmentInfo.Explain}";

        shirtEquipmentListImage.sprite = Resources.Load(upperEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        shirtEquipmentPart.text = $"{CommonDefineKR.UpperString}";
        shirtEquipmentTitle.text = $"{upperEquipmentInfo.Name}";
        shirtEquipmentDescription.text = $"{upperEquipmentInfo.Explain}";

        pantsEquipmentListImage.sprite = Resources.Load(underEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        pantsEquipmentPart.text = $"{CommonDefineKR.UnderString}";
        pantsEquipmentTitle.text = $"{underEquipmentInfo.Name}";
        pantsEquipmentDescription.text = $"{underEquipmentInfo.Explain}";

        weaponEquipmentListImage.sprite = Resources.Load(weaponEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        weaponEquipmentPart.text = $"{CommonDefineKR.WeaponString}";
        weaponEquipmentTitle.text = $"{weaponEquipmentInfo.Name}";
        weaponEquipmentDescription.text = $"{weaponEquipmentInfo.Explain}";

        trinketEquipmentListImage.sprite = Resources.Load(accessoryEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        trinketEquipmentPart.text = $"{CommonDefineKR.AccessoryString}";
        trinketEquipmentTitle.text = $"{accessoryEquipmentInfo.Name}";
        trinketEquipmentDescription.text = $"{accessoryEquipmentInfo.Explain}";

        etcEquipmentListImage.sprite = Resources.Load(oddmentsEquipmentInfo.ImagePath, typeof(Sprite)) as Sprite;
        etcEquipmentPart.text = $"{CommonDefineKR.OddmentsString}";
        etcEquipmentTitle.text = $"{oddmentsEquipmentInfo.Name}";
        etcEquipmentDescription.text = $"{oddmentsEquipmentInfo.Explain}";
    }
}
