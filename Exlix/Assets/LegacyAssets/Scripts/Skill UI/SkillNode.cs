using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillNode : MonoBehaviour, IObserver<PlayerStateInfo> {
    [SerializeField] public SkillNode pSkill; //선행 스킬
    [SerializeField] Image nodeImage = null;
    [SerializeField] SkillInfoPopup skillPopup = null; //스킬정보 팝업
    [SerializeField] PlayerState _PlayerState = null;

    public int skillId;
    public bool isActivated; //스킬 활성화 여부

    // Start is called before the first frame update
    void Start() {
        isActivated = _PlayerState._PlayerStateInfoHandler.GetCurrentSkillUnlocked(skillId);
    }

    // Update is called once per frame
    void Update() {
        if (!isActivated) {
            nodeImage.color = new Color(0.2f, 0.2f, 0.2f, 1);
        }
        else {
            nodeImage.color = new Color(1, 1, 1, 1);
        }
    }

    //스킬 정보팝업 활성화
    public void PopupActive() {
        skillPopup.PopupActive(this);
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(PlayerStateInfo value)
    {
        isActivated = value.unlockedSkill[skillId];
    }
}
