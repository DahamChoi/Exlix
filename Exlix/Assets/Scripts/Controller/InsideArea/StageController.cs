using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    [SerializeField] public Transform selectionContainer;
    [SerializeField] public Transform sentencePannel;
    [SerializeField] public ScrollRect pannelScroll;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateSentence(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateSentence(int sentenceId) {
        FactoryManager.GetInstance().CreateSentenceObject(sentenceId, this, sentencePannel);
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)sentencePannel);
        pannelScroll.verticalNormalizedPosition = 0;
    }
}
