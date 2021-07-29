using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMaintenance_Skill_Layer : MonoBehaviour {
    CharacterInfoDTO characterInfo = null;
    public List<GameObject> skillNode = null;
    private void Start() {
        Init();
    }
    void Init() {
        characterInfo = CharacterInfoDAO.GetCharacterInfo();        
    }
    public void UpdateUI() {
        for (int i = 0; i<skillNode.Count; i++) {
            skillNode[i].GetComponent<SkillObject>().UpdateIcon();
        }
    }
    public void AddNode(GameObject node) {
        skillNode.Add(node);
    }
}
