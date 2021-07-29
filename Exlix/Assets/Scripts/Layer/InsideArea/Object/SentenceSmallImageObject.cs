using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceSmallImageObject : MonoBehaviour {
    [SerializeField] Text sentenceText = null;
    [SerializeField] Image sentenceImage = null;
    public void Init(string sentenceString, string imagePath) {
        sentenceText.text = sentenceString;
        sentenceImage.sprite = Resources.Load(imagePath, typeof(Sprite)) as Sprite;
    }
}
