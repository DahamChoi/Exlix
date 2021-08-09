using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InsideAreaLayerController : MonoBehaviour {
    
    [SerializeField] InsideAreaHandler insideAreaHandler;

    private void Start() {
        // Get To Information

        insideAreaHandler.AddSentence(1);
    }
}
