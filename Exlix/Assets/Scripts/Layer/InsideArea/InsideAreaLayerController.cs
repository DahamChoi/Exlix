using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InsideAreaLayerController : MonoBehaviour {
    
    private void Start() {
        // Get To Information
        //AreaDTO
        //GameState.GetInstance().GetData<AreaDTO>(InformationKeyDefine.CURRENT_AREA_NUMBER_KEY).)
        SceneState.GetInstance()._InsideAreaHandler.AddSentence(1);
    }
}
