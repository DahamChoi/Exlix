using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionObject : MonoBehaviour {
    SelectionDTO SelectionData;
    [SerializeField] Text SelectionText;
    public void init(SelectionDTO selectionData) {
        SelectionData = selectionData;

        SelectionText.text = selectionData.Text;
    }
}
