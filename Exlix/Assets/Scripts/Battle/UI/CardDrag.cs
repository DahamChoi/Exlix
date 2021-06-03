using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	RectTransform rectT;
	Vector3 tempV;
	float screenAdaptiveSize;
	//앵커드 포지션을 써라 지훈아

	public void OnBeginDrag(PointerEventData eventData) {
		tempV = this.transform.localScale;
		GameObject.Find("GameManager").GetComponent<CardTransformChanger>().SpreadCardPosition(this.GetComponent<CardTransformData>().TempCardIndex);
	}

	public void OnDrag(PointerEventData eventData) {
		Debug.Log("드래그 중");
		rectT.anchoredPosition = ((eventData.position - new Vector2((float)Screen.width / 2, (float)Screen.height / 2)) * screenAdaptiveSize);
		this.GetComponent<CardTransformData>().TargetPosition = rectT.position;
		this.GetComponent<CardTransformData>().TargetAngle = 0f;
		this.GetComponent<SpriteRenderer>().sortingOrder = 11;
		this.transform.localScale = new Vector3(100, 100, 1);
	}

	public void OnEndDrag(PointerEventData eventData) {
		if (eventData.position.y > 300) 
		GameObject.Find("GameManager").GetComponent<CardTransformChanger>().CalCardsTransform();
		this.transform.localScale = tempV;
		//throw new System.NotImplementedException();
	}

	// Start is called before the first frame update
	void Start() {
		if ((float)Screen.width / Screen.height < 18 / 9) screenAdaptiveSize = (float)2880 / Screen.width;
		else screenAdaptiveSize = (float)1440 / Screen.height;
		rectT = this.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update() {

	}
}
