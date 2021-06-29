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

    public void PopupActive(SkillNode data) {
        skillNode = data;
        Name.text = "Test Skill";
        Explain.text = "Test Skill Explain";
        gameObject.SetActive(true);
    }

    public void SkillActive() {
        skillNode.isActivated = true;
        gameObject.SetActive(false);
    }

    public void PopupDeactive() {
        gameObject.SetActive(false);
    }
}
