using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionTextObject : MonoBehaviour
{
    [SerializeField] Text selectionText;

    public void Init(string _selectionText) {
        selectionText.text = _selectionText;
    }
}
