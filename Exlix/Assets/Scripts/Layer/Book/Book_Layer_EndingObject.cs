using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Book_Layer_EndingObject : MonoBehaviour, IPointerClickHandler {
    [SerializeField] GameObject coverImage = null;
    int endingID;

    public void OnPointerClick(PointerEventData eventData) {
        if(coverImage.activeSelf) return;
        FactoryManager.GetInstance().CreateBookEndingPopup(transform.parent.transform.parent);//...데이터 추가예정
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
    
    void Init(int _endingID) {
        endingID = _endingID;
        //... 이미지 변경
    }
}
