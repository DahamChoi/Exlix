using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InsideAreaLayerController : MonoBehaviour {
    
    private void Start() {
        // Get To Information

        SceneState.GetInstance()._InsideAreaHandler.AddSentence(1);
    }
}
