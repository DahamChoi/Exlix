using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsideAreaCharacterInfoController : MonoBehaviour {
    [SerializeField] RectTransform characterInfoRect = null;
    [SerializeField] RectTransform arrowRect = null;
    [SerializeField] Button characterInfoButton = null;
    bool IsOpened = false;

    void Start() {
        characterInfoButton.onClick.AddListener(() => {
            Vector3 movePosition = IsOpened ? new Vector3(1000.0f, 0.0f) : new Vector3(-1000.0f, 0.0f);
            SlideTo moveAction = SlideTo.Create(characterInfoRect.gameObject, movePosition, 0.5f);
            ActionManager.GetInstance().RunAction(moveAction);
            arrowRect.rotation = IsOpened ? new Quaternion(0, 0, 0, 0) : new Quaternion(0, 0, 180, 0);
            IsOpened = !IsOpened;
        });
    }

    // Update is called once per frame
    void Update() {

    }
}
