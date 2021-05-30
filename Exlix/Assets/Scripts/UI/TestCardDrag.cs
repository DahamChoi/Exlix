using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestCardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	RectTransform rectT;
	Vector3 tempV;
	//앵커드 포지션을 써라 지훈아

	public void OnBeginDrag(PointerEventData eventData) {
		tempV = this.transform.localScale;
		GameObject.Find("GameManager").GetComponent<CardTransformChanger>().SpreadCardPosition(this.GetComponent<CardTransformData>().TempCardIndex);
	}

	public void OnDrag(PointerEventData eventData) {
		Debug.Log("드래그 중");
		rectT.anchoredPosition = eventData.position;
		this.GetComponent<CardTransformData>().TargetPosition = rectT.position;
		this.GetComponent<CardTransformData>().TargetAngle = 0f;
		this.GetComponent<SpriteRenderer>().sortingOrder = 11;
		this.transform.localScale = new Vector3(80, 80, 1);
	}

	public void OnEndDrag(PointerEventData eventData) {
		GameObject.Find("GameManager").GetComponent<CardTransformChanger>().CalCardsTransform();
		this.transform.localScale = tempV;
		//throw new System.NotImplementedException();
	}

	// Start is called before the first frame update
	void Start() {
		rectT = this.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update() {

	}
}
