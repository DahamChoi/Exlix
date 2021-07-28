using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentencePanelWhiteSpace : MonoBehaviour {
    //마진용 코드
    void Update() {
        transform.SetSiblingIndex(transform.childCount - 1);
    }
}
