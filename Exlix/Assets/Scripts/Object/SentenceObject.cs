using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceObject : MonoBehaviour {

    [SerializeField] Transform selectionContainor;
    [SerializeField] Text sentenceText;
    SentenceDTO sentenceData;

    public void Init(SentenceDTO _sentenceData, Transform _selectionContainer) {
        sentenceData = _sentenceData;
        selectionContainor = _selectionContainer;
        sentenceText.text = sentenceData.Text;

        GameObject sentenceImage = new GameObject();
        if(_sentenceData.IsHavePicture == 1) sentenceImage = FactoryManager.GetInstance().CreateSentenceImageObject(_sentenceData.ImagePath, transform.parent);
        sentenceImage.transform.SetSiblingIndex(transform.GetSiblingIndex());

        if (sentenceData.SelectionList != null) {
            foreach (var selection in sentenceData.SelectionList){
                FactoryManager.GetInstance().CreateSelectionObject(selection, transform.parent, selectionContainor);
            }
        }

    }
}
