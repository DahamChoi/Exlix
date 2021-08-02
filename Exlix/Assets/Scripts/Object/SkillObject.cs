using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillObject : MonoBehaviour, IObserver<UIStateInfo> {
    [SerializeField] int skillID;
    [SerializeField] Image skillImage = null;
    [SerializeField] Button skillButton = null;
    [SerializeField] Transform popupContainer = null;
    [SerializeField] Transform parent =null;

    SkillDTO skillData;
    int status = 0;//1 - �������� ��ų 2 - Ȱ��ȭ�� ��ų 3 - ��Ȱ��ȭ�� ��ų 

    void Start() {
        InitObject();
        FactoryManager.GetInstance().CreateLineObject(this.gameObject.transform.position, parent.transform.position, skillData ,this.gameObject.transform.parent);
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();
    }

    void InitObject() {
        skillData = SkillDAO.GetSelectedSkillInfo(skillID);
        skillImage.sprite = Resources.Load(skillData.ImagePath, typeof(Sprite)) as Sprite;
        skillButton.onClick.AddListener(() => {
            FactoryManager.GetInstance().CreateSelectedSkillPopup(skillData, popupContainer);
        });
        UpdateIcon();
    }
    public void UpdateIcon() {
        if (CharacterInfoDAO.GetCharacterInfo().CurrentSkill == skillID) {//status = 1 - �������� ��ų
            skillImage.color = new Color(1f, 0f, 0f, 1f); // ���� �۷ο� ȿ���� ����
        }
        else if (CharacterInfoDAO.GetCharacterInfo().UnLockedSkill.Contains(skillData.Number)) {//status = 2 Ȱ��ȭ�� ��ų
            skillImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else {//status = 3 ��Ȱ��ȭ 
            skillImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }
    public void OnNext(UIStateInfo value) {
        UpdateIcon();
    }
    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }
}