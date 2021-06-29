using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoPopup : MonoBehaviour
{
    [SerializeField] Text Name;
    [SerializeField] Text Explain;
    SkillNode skillNode;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // 스킬 정보 팝업 활성화
    public void PopupActive(SkillNode data) {
        skillNode = data;
        Name.text = "Test Skill";
        Explain.text = "Test Skill Explain";
        gameObject.SetActive(true);
    }

    // 스킬 활성화
    public void SkillActive() {
        skillNode.isActivated = true;
        gameObject.SetActive(false);
    }

    // 스킬 정보 팝업 비활성화
    public void PopupDeactive() {
        gameObject.SetActive(false);
    }
}
