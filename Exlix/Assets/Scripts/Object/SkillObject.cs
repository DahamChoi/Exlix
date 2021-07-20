using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillObject : MonoBehaviour {
    [SerializeField] int skillID;
    [SerializeField] Image skillImage;
    [SerializeField] Button skillButton;
    [SerializeField] Transform PopupContainer;
    SkillDTO skillData;

    // Start is called before the first frame update
    void Start() {
        Init();
    }

    void Init() {
        skillData = SkillDAO.GetSelectedSkillInfo(skillID);
        skillImage.sprite = Resources.Load(skillData.ImagePath, typeof(Sprite)) as Sprite;

        skillButton.onClick.AddListener(() => { 
            FactoryManager.GetInstance().CreateSelectedSkillPopup(skillData, PopupContainer);
         });

        if (CharacterInfoDAO.GetCharacterInfo().CurrentSkill == skillID) skillImage.color = new Color(1f, 0f, 0f, 1f);
        else if (CharacterInfoDAO.GetCharacterInfo().UnLockedSkill != null ? false : CharacterInfoDAO.GetCharacterInfo().UnLockedSkill.Contains(skillData.Parent)) 
                skillImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }
}
