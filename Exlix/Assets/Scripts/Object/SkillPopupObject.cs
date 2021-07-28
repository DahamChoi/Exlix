using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPopupObject : MonoBehaviour {

    CharacterInfoDTO characterData;
    [SerializeField] Image skillImage = null;
    [SerializeField] Text title = null;
    [SerializeField] Text coolTime = null;
    [SerializeField] Text explain = null;
    [SerializeField] Button skillActivationButton = null;
    [SerializeField] Button skillPopupBackgroundButton = null;
    [SerializeField] Text skillButtonText = null;
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

    //팝업창 내부의 버튼 변경함수
    void SetButton() {
        skillActivationButton.onClick.RemoveAllListeners();
        //장착중인 스킬
        if (characterData.CurrentSkill == selectedSkillData.Number) {
            //skillActivationButton.image.sprite = Resources.Load("alreadyEquipedSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.AlreadyEquipedSkillString}";
            skillActivationButton.interactable = false;
        }
        //해금완료된 스킬
        else if (characterData.UnLockedSkill.Contains(selectedSkillData.Number)) {
            //skillActivationButton.image.sprite = Resources.Load("EquipSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.EquipSkillString}";
            skillActivationButton.interactable = true;
            
            skillActivationButton.onClick.AddListener(() => {
                characterData.CurrentSkill = selectedSkillData.Number;
                //...
                SetButton();
            });
        }
        //해금이 가능한 스킬
        else if (characterData.UnLockedSkill.Contains(selectedSkillData.Parent)) {
            //skillActivationButton.image.sprite = Resources.Load("UnlockSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.UnlockSkillString}";
            skillActivationButton.interactable = true;

            skillActivationButton.onClick.AddListener(() => {
                characterData.UnLockedSkill.Add(selectedSkillData.Number);
                //...
                SetButton();
            });
        }
        //상위노드의 해금이 필요한 스킬
        else {
            //skillActivationButton.image.sprite = Resources.Load("LockedSkillButtonImageUIPath...", typeof(Sprite)) as Sprite;
            skillButtonText.text = $"{CommonDefineKR.LockedSkillString}";
            skillActivationButton.interactable = false;
        }
    }
}
