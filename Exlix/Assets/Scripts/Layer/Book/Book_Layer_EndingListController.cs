using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Layer_EndingListController : MonoBehaviour {
    [SerializeField] Transform endingContainer = null;
    List<GameObject> endingObjectList = new List<GameObject>();
    
    void OnEnable() {
        if(endingObjectList != null) {
            foreach (GameObject endingObject in endingObjectList) {
                Destroy(endingObject);
            }
            endingObjectList.Clear();
        }

        List<int> endingEntireList = new List<int>();
        //... 리스트 불러오기
        if (endingEntireList != null) return;
        foreach(var endingData in endingEntireList) {
            endingObjectList.Add(FactoryManager.GetInstance().CreateBookEnding(endingContainer));
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }



}
