using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillBGDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IScrollHandler {
    [SerializeField] RectTransform rectTransform;
    Vector2 startPos;

	// Start is called before the first frame update
	void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //클릭시에 위치값 저장
    public void OnPointerDown(PointerEventData eventData) {
        startPos = eventData.position;
    }

    //위치값 변경수치 만큼 오브젝트 이동
    public void OnDrag(PointerEventData eventData) {
        Vector2 movePos = eventData.position - startPos;
        startPos = eventData.position;

        rectTransform.anchoredPosition += movePos;
    }

    //스크롤을 이용해 확대 축소
	public void OnScroll(PointerEventData eventData) {
        if (eventData.scrollDelta.y > 0) {
            rectTransform.localScale -= new Vector3(0.1f, 0.1f, 1f);
        }
        else if (eventData.scrollDelta.y < 0) {
            rectTransform.localScale += new Vector3(0.1f, 0.1f, 1f);
        }
    }
}
