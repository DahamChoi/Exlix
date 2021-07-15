using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsideAreaCharacterInfoController : MonoBehaviour {
    [SerializeField] RectTransform characterInfoRect = null;
    [SerializeField] RectTransform arrowRect = null;
    [SerializeField] Button characterInfoButton = null;
    bool IsOpened = false;

    // Start is called before the first frame update
    void Start() {
        characterInfoButton.onClick.AddListener(() => {
            if (IsOpened) {
                characterInfoRect.anchoredPosition = new Vector2(-69.5f, -59.75f); //나중에 애니메이션으로 부드럽게 만들 예정
                arrowRect.rotation = new Quaternion(0, 0, 0, 0);
                IsOpened = false;
            } else {
                characterInfoRect.anchoredPosition = new Vector2(-1056.8f, -59.75f); //나중에 애니메이션으로 부드럽게 만들 예정
                arrowRect.rotation = new Quaternion(0, 0, 180, 0);
                IsOpened = true;
            }
        });
    }

    // Update is called once per frame
    void Update() {

    }
}
