using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceImageObject : MonoBehaviour {
    [SerializeField] Image sentenceImage;
    public void Init(string imagePath) {
        sentenceImage.sprite = Resources.Load(imagePath, typeof(Sprite)) as Sprite;
    }
}
