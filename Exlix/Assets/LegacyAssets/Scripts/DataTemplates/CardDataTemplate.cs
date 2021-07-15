using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataTemplate {
    public Dictionary<string, string> Data = new Dictionary<string, string>();

    public string GetCardData(string key) {
        return Data[key];
    }
}