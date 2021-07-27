using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GridLayout : MonoBehaviour {
    [SerializeField] RectTransform rectTransform = null;
    [SerializeField] float heightSpacing = 0;
    [SerializeField] float widthSpacing = 0;
    List<Transform> childList = new List<Transform>();

    void Start() {
        //RefreshGrid();
    }

    void Init() {
        childList.Clear();
        for (int i = 0; i < transform.childCount; i++)
            childList.Add(transform.GetChild(i));
    }

    public void RefreshGrid() {
        Init();
        CalculateLayout();
    }

    void CalculateLayout() {
        float leftWidth = rectTransform.rect.width;
        float contentsHeight = 0;

        for (int i = 0; i < transform.childCount; i++) {
            RectTransform contentRect = childList[i].GetComponent<RectTransform>();

            //남은 width 값이 넣으려는 컨텐츠보다 작거나 줄의 처음이 아닐때 직전 컨텐츠의 높이값만큼 포인터 변경
            if (leftWidth < contentRect.rect.width && leftWidth != rectTransform.rect.width) {
                contentsHeight -= (childList[i - 1].GetComponent<RectTransform>().rect.height + heightSpacing);
                leftWidth = rectTransform.rect.width;
            }

            contentRect.localPosition = new Vector2(rectTransform.rect.width - leftWidth, contentsHeight);
            leftWidth -= (rectTransform.rect.width + widthSpacing);
        }
        //rectTransform.rect.Set();
    }
}
