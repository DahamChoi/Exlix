using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceObject : MonoBehaviour {

    [SerializeField] Text sentenceText;
    SentenceDTO SentenceData;

    public void init(SentenceDTO sentenceData) {
        SentenceData = sentenceData;
        sentenceText.text = sentenceData.Text;
        GameObject sentenceImage = new GameObject();
        if(sentenceData.IsHavePicture == 1) sentenceImage = FactoryManager.GetInstance().CreateSentenceImageObject(sentenceData.ImagePath, transform.parent);
        sentenceImage.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }
}
