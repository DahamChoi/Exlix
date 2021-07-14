using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceObject : MonoBehaviour {

    [SerializeField] Text sentenceText;
    InsideAreaLayerController insideAreaLayerController;
    SentenceDTO sentenceData;

    public void Init(SentenceDTO _sentenceData, InsideAreaLayerController _insideAreaLayerController) {
        sentenceData = _sentenceData;
        insideAreaLayerController = _insideAreaLayerController;
        sentenceText.text = sentenceData.Text;

        GameObject sentenceImage = new GameObject();
        if(_sentenceData.IsHavePicture == 1) sentenceImage = FactoryManager.GetInstance().CreateSentenceImageObject(_sentenceData.ImagePath, transform.parent);
        sentenceImage.transform.SetSiblingIndex(transform.GetSiblingIndex());

        if (sentenceData.SelectionList != null) {
            foreach (var selection in sentenceData.SelectionList){
                FactoryManager.GetInstance().CreateSelectionObject(selection, insideAreaLayerController.selectionContainer);
            }
        }

    }
}
