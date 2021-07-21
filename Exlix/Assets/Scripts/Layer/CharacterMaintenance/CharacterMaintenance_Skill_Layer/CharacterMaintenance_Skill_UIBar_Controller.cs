using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMaintenance_Skill_UIBar_Controller : MonoBehaviour {
    [SerializeField] Button backToMainButton = null;
    [SerializeField] Button settingButton = null;

    // Start is called before the first frame update
    void Start() {
        backToMainButton.onClick.AddListener(()=>{

        });
        settingButton.onClick.AddListener(()=>{

        });
    }

    // Update is called once per frame
    void Update() {

    }
}
