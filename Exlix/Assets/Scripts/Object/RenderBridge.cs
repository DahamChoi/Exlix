using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class RenderBridge : MonoBehaviour, IObserver<UIStateInfo> {
    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    Vector3 parentPosition = Vector3.zero;//현재
    Vector3 parentPosition_2 = Vector3.zero;//과거
    Vector3 offset = Vector3.zero;

    bool initialized = false;

    object temp = null;

    SkillDTO skill = null;
    EquipmentDTO equip = null;
    Type type = null;

    Color activatedColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    Color inActivatedColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    Color glowingActivatedColor = new Color(1.0f,0.0f,0.0f,1.0f);

    void Start() {
        SceneState.GetInstance()._UIStateHandler.Subscribe(this);
        SceneState.GetInstance()._UIStateHandler.NotifyObservers();
    }

    private void Update() {
        if (initialized) {
            parentPosition = this.gameObject.transform.parent.position;
            offset.x = parentPosition.x - parentPosition_2.x;
            offset.y = parentPosition.y - parentPosition_2.y;
            parentPosition_2 = parentPosition;

            startPosition = new Vector3(startPosition.x + offset.x, startPosition.y + offset.y , startPosition.z + offset.z);
            endPosition = new Vector3(endPosition.x + offset.x, endPosition.y + offset.y, endPosition.z + offset.z);

            this.GetComponent<LineRenderer>().SetPosition(0, startPosition);  
            this.GetComponent<LineRenderer>().SetPosition(1, endPosition);
        }
    }

    public void Init<T>(Vector3 start, Vector3 end, T data) {
        type = typeof(T);
        if(type == typeof(SkillDTO)) {
            skill = (SkillDTO)Convert.ChangeType(data, type);
            Debug.Log("skill");
            Debug.Log(skill.Number);
        }
        else {
            //equip = data;
            equip = (EquipmentDTO)Convert.ChangeType(data, type);
            Debug.Log("Equip");
        }
        parentPosition = this.gameObject.transform.parent.position;
        parentPosition_2 = this.gameObject.transform.parent.position;
        startPosition = start;
        endPosition = end;
        this.GetComponent<LineRenderer>().SetPosition(0, startPosition);
        this.GetComponent<LineRenderer>().SetPosition(1, endPosition);
        parentPosition = this.transform.parent.position;
        initialized = true;
    }

    public void UpdateBridgeStatus() {
        CharacterInfoDTO character = CharacterInfoDAO.GetCharacterInfo();

        bool isChildUnlocked;
        bool isParentUnlocked;
        List<int> List;

        if (type == typeof(SkillDTO)) {
             List = character.UnLockedSkill;
             isChildUnlocked = List.Contains(skill.Number);
             isParentUnlocked = List.Contains(skill.Parent);
        }
        else {
            List = character.HaveEquipmentList;
            isChildUnlocked = List.Contains(equip.Number);
            isParentUnlocked = List.Contains(equip.Parent);
        }


        if (isChildUnlocked) {//선 활성화상태 (밝은채도의 선) 
            //부모(활성화) & 자식(활성화)
            this.gameObject.GetComponent<LineRenderer>().startColor = activatedColor;
            this.gameObject.GetComponent<LineRenderer>().endColor = activatedColor;
        }
        else {//자식이 비활성화인경우
            if (isParentUnlocked) {//밝은채도의 선, 글로우 효과
                                   //부모(활성화)&자식(비활성화)
                this.gameObject.GetComponent<LineRenderer>().startColor = glowingActivatedColor;
                this.gameObject.GetComponent<LineRenderer>().endColor = glowingActivatedColor;
            }
            else {//어두운 무채색 선
                  // 부모(비활성화)&자식(비활성화)
                this.gameObject.GetComponent<LineRenderer>().startColor = inActivatedColor;
                this.gameObject.GetComponent<LineRenderer>().endColor = inActivatedColor;
            }
        }
    }

    public void OnNext(UIStateInfo value) {
        UpdateBridgeStatus();
    }
    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }
}
