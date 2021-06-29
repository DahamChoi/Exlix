﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraResize : MonoBehaviour
{
	void Awake() {
		Camera camera = GetComponent<Camera>();
		Rect rect = camera.rect;
		float scaleHeight = ((float)Screen.width / Screen.height) / ((float)18 / 9);
		float scaleWidth = 1f / scaleHeight;
		if (scaleHeight < 1) {
			rect.height = scaleHeight;
			rect.y = (1f - scaleHeight) / 2f;
		}
		else {
			rect.width = scaleWidth;
			rect.x = (1f - scaleWidth) / 2;
		}
		camera.rect = rect;
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}