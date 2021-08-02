using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPopupObject : MonoBehaviour {
    [SerializeField] Button backgroundButton = null;
    [SerializeField] Button closeButton = null;
    [SerializeField] Button equipButton = null;
    [SerializeField] Image equipmentIconImage = null;
    [SerializeField] Image equipButtonImage = null;
    [SerializeField] Text title = null;
    [SerializeField] Text price = null;
    [SerializeField] Text description = null;

    // Start is called before the first frame update
    void Start() {

    }

    public void Init(EquipmentDTO equipmentData) {
        
    }
}
