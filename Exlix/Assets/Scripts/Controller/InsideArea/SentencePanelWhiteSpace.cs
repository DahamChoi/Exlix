using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentencePanelWhiteSpace : MonoBehaviour {
    void Update() {
        transform.SetSiblingIndex(transform.childCount - 1);
    }
}
