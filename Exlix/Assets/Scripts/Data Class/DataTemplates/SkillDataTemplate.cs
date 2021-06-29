using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataTemplate {
    public Dictionary<string, string> Data = new Dictionary<string, string>();

    public string GetSkillData(string key) {
        return Data[key];
    }
}