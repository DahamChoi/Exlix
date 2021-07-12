using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceObject : MonoBehaviour {
    SentenceDTO SentenceData;
    [SerializeField] Text sentenceText;
    public void init(SentenceDTO sentenceData) {
        SentenceData = sentenceData;

        sentenceText.text = sentenceData.Text;
    }
}
