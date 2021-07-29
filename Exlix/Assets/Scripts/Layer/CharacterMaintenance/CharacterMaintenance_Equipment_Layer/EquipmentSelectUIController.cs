using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelectUIController : MonoBehaviour {
    [SerializeField] Button headEquipmentSlotButton = null;
    [SerializeField] Button upperEquipmentSlotButton = null;
    [SerializeField] Button underEquipmentSlotButton = null;
    [SerializeField] Button weaponEquipmentSlotButton = null;
    [SerializeField] Button accessoryEquipmentSlotButton = null;
    [SerializeField] Button oddmentEquipmentSlotButton = null;

    // Start is called before the first frame update
    void Start() {
        headEquipmentSlotButton.onClick.AddListener(() => {

        });
        upperEquipmentSlotButton.onClick.AddListener(() => {

        });
        underEquipmentSlotButton.onClick.AddListener(() => {

        });
        weaponEquipmentSlotButton.onClick.AddListener(() => {

        });
        accessoryEquipmentSlotButton.onClick.AddListener(() => {

        });
        oddmentEquipmentSlotButton.onClick.AddListener(() => {

        });
    }

}
