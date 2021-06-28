using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoPopup : MonoBehaviour
{
    [SerializeField] GameObject skillInfoWindow;
    [SerializeField] Text Name;
    [SerializeField] Text Explain;

    NodeData nodeData;

    // Start is called before the first frame update
    void Start() {
        nodeData = gameObject.GetComponent<NodeData>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void PopupSkillInfo() {
        skillInfoWindow.SetActive(true);
        Name.text = "Test Skill";
        Explain.text = "Test Skill Explain";
    }
}
