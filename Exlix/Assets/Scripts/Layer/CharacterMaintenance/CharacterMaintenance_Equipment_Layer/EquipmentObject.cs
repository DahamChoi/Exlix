using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentObject : MonoBehaviour, IObserver<UIStateHandler> {
    [SerializeField] EquipmentObject parent = null;
    [SerializeField] List<EquipmentObject> childrens = new List<EquipmentObject>();
    [SerializeField] GameObject bridge = null;
    EquipmentDTO equipmentData;

    public void OnCompleted() {
        throw new NotImplementedException();
    }

    public void OnError(Exception error) {
        throw new NotImplementedException();
    }

    public void OnNext(UIStateHandler value) {
        throw new NotImplementedException();
    }

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
