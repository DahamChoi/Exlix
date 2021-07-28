using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour {
    List<GameObject> selectionList = new List<GameObject>();
    [SerializeField] InsideAreaLayerController insideAreaLayerController = null;

    public void AddSelection(GameObject gameObject) {
        selectionList.Add(gameObject);
    }

    public void SelectSelection(SelectionDTO selectionData) {
        insideAreaLayerController.SelectSelection(selectionData);
    }
    
    public void Destroy() {
        foreach (GameObject selection in selectionList) {
            Destroy(selection);
        }
        selectionList.Clear();
    }
}
