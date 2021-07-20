using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMaintenance_Skill_UIController : MonoBehaviour {
    List<int> unlockedSkill = new List<int>();

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public bool isUnlocked(int skillID) {
        return unlockedSkill.Contains(skillID);
    }
}
