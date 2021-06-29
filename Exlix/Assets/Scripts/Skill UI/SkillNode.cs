using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //NodeConnection(pSkill.gameObject.GetComponent<RectTransform>().anchoredPosition, gameObject.GetComponent<RectTransform>().anchoredPosition);
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

    //노드 사이에 선을 연결함 (작업중
    void NodeConnection(Vector2 dotPositionA, Vector2 dotPositionB) {
        GameObject tempGameObject = Instantiate(lineImage, gameObject.transform);
        //자기 자신(dotConnection)의 크기를 조정하기위해 RectTransform의값을 불러옴
        RectTransform tempRectTransform = tempGameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        tempRectTransform.sizeDelta = new Vector2(distance, 30f);
        tempRectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        tempRectTransform.localEulerAngles = new Vector3(0, 0, n);
    }
}
