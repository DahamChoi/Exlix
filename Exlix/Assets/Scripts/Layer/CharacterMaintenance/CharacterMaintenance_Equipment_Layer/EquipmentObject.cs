using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentObject : MonoBehaviour {
    [SerializeField] EquipmentObject parent = null;
    [SerializeField] List<EquipmentObject> childrens = new List<EquipmentObject>();
    [SerializeField] GameObject bridge = null;
    EquipmentDTO equipmentData;

    protected void ChildOnNext() {
        if (childrens != null) {

            foreach (var child in childrens) {
                child.ChildOnNext();
            }
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


}
