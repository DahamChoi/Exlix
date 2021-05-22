using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//화면의 레터박스영역을 지정, 검은색으로 칠함
public class ScreenLetterBox : MonoBehaviour {
	void Awake() {
		Camera camera = GetComponent<Camera>();
		Rect rect = camera.rect;
		float scaleHeight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
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

	void OnPreCull() => GL.Clear(true, true, Color.black);

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
}
