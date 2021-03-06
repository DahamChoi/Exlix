using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomContentSizeFitter : MonoBehaviour {
    [SerializeField] List<RectTransform> flexibleObjects = new List<RectTransform>();
    [SerializeField] RectTransform targetRectTransform = null;
    [SerializeField] float targetPannelCommonheight = 0;
    public void UpdateSize() {
        float flexibleHeight = 0;
        foreach (var _object in flexibleObjects) {
            flexibleHeight += _object.rect.height;
        }
        targetRectTransform.sizeDelta = new Vector2(targetRectTransform.rect.width, targetPannelCommonheight + flexibleHeight);
    }

    void Update() {
        UpdateSize();
    }
}
