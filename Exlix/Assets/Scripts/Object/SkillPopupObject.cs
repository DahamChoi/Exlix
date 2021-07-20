using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPopupObject : MonoBehaviour {

    [SerializeField] CharacterInfoDTO characterData;
    [SerializeField] Image skillImage;
    [SerializeField] Text title;
    [SerializeField] Text coolTime;
    [SerializeField] Text explain;
    [SerializeField] Button skillActivationButton;
    [SerializeField] Button skillPopupBackgroundButton;
    [SerializeField] Text skillButtonText;
    SkillDTO selectedSkillData;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Init(SkillDTO _skillData) {
        skillPopupBackgroundButton.onClick.AddListener(() => {
            Destroy(this.gameObject);
        });
        selectedSkillData = _skillData;
        characterData = CharacterInfoDAO.GetCharacterInfo();

        skillImage.sprite = Resources.Load(selectedSkillData.ImagePath, typeof(Sprite)) as Sprite;
        title.text = $"{selectedSkillData.Name}";
        coolTime.text = $"{CommonDefineKR.SkillCooltimeString} {CommonDefineKR.TurnString} : {selectedSkillData.CoolTime}{CommonDefineKR.TurnString}";
        explain.text = $"{selectedSkillData.Explain}";
        SetButton();
    }

    void SetButton() {
        skillActivationButton.onClick.RemoveAllListeners();

        if (characterData.CurrentSkill == selectedSkillData.Number) {
            //skillActivationButton.image.sprite = Resources.Load("alreadyEquipedSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.AlreadyEquipedSkillString}";
            skillActivationButton.interactable = false;
        } else if (characterData.UnLockedSkill.Contains(selectedSkillData.Number)) {
            //skillActivationButton.image.sprite = Resources.Load("EquipSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.EquipSkillString}";
            skillActivationButton.interactable = true;
            skillActivationButton.onClick.AddListener(() => {
                characterData.CurrentSkill = selectedSkillData.Number;
                //...
                SetButton();
            });
        } else if (characterData.UnLockedSkill.Contains(selectedSkillData.Parent)) {
            //skillActivationButton.image.sprite = Resources.Load("UnlockSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.UnlockSkillString}";
            skillActivationButton.interactable = true;
            skillActivationButton.onClick.AddListener(() => {
                characterData.UnLockedSkill.Add(selectedSkillData.Number);
                //...
                SetButton();
            });
        } else {
            //skillActivationButton.image.sprite = Resources.Load("LockedSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.LockedSkillString}";
            skillActivationButton.interactable = false;
        }
    }
}
