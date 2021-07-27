using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SentenceObject : MonoBehaviour {

    [SerializeField] Text sentenceText = null;
    InsideAreaLayerController insideAreaLayerController;
    SentenceDTO sentenceData;

    public void Init(SentenceDTO _sentenceData, InsideAreaLayerController _insideAreaLayerController) {
        sentenceData = _sentenceData;
        insideAreaLayerController = _insideAreaLayerController;
        //sentenceText.text = sentenceData.Text;
        GameObject sentenceImage = new GameObject();
        if (_sentenceData.IsHavePicture == 1) {
            sentenceImage = FactoryManager.GetInstance().CreateSentenceImageObject(_sentenceData.ImagePath, transform.parent);
            sentenceImage.transform.SetSiblingIndex(transform.GetSiblingIndex());
        }
        else if (_sentenceData.IsHavePicture == 2) {
            string cropString; //= sentenceText.text.Substring(0, 100);
            //sentenceText.text = sentenceText.text.Substring(100);

            cropString = sentenceText.text.Split('|')[0];
            sentenceText.text = sentenceText.text.Split('|')[1];

            sentenceImage = FactoryManager.GetInstance().CreateSentenceSmallImageObject(cropString, _sentenceData.ImagePath, transform.parent);
            sentenceImage.transform.SetSiblingIndex(transform.GetSiblingIndex());
        }

        if (sentenceData.SelectionList != null) {
            foreach (var selection in sentenceData.SelectionList) {
                FactoryManager.GetInstance().CreateSelectionObject(selection, insideAreaLayerController.GetSelectionContainer());
            }
        }

    }
}
