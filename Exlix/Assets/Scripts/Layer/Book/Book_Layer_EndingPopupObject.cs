using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book_Layer_EndingPopupObject : MonoBehaviour {
    [SerializeField] Button backgroundButton = null;
    [SerializeField] Image endingImage = null;
    [SerializeField] Text titleText = null;
    [SerializeField] Text descriptionText = null;

    // Start is called before the first frame update
    void Start() {
        backgroundButton.onClick.AddListener(() => {
            Destroy(this.gameObject);
        });
    }


    void Init() {
        //...데이터 입력
    }
}
