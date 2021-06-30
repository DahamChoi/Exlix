using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SkillNode : MonoBehaviour {
    [SerializeField] SkillNode pSkill; //선행 스킬
    [SerializeField] GameObject lineImage;
    [SerializeField] Image nodeImage;
    [SerializeField] SkillInfoPopup skillPopup; //스킬정보 팝업

    public bool isActivated; //스킬 활성화 여부

    // Start is called before the first frame update
    void Start() {
        if (pSkill == null) return;
        isActivated = false;
    }

    // Update is called once per frame
    void Update() {
        if (!isActivated) {
            nodeImage.color = new Color(0.2f, 0.2f, 0.2f, 1);
        }
        else {
            nodeImage.color = new Color(1, 1, 1, 1);
        }
        CheckPNode();
    }

    //부모노드가 비활성화되면 자신도 비활성화
    void CheckPNode() {
        if (pSkill == null) return;
        if (!pSkill.isActivated) isActivated = false;
    }

    //스킬 정보팝업 활성화
    public void PopupActive() {
        if (!pSkill.isActivated) return;
        if (!isActivated) skillPopup.PopupActive(this);
    }

}
