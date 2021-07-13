using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	[SerializeField]Camera targetCamera;//프리팹화했을때 카메라에 접근방법 생각해보기
	//덱 정렬기준에따라 재배치해야함.
	//카드 버리기 영역에 드랍할경우 리스트에서 해당 카드 삭제. 들고있는카드는 UIState에 등록해 들고있다가 그대로 갖다 버리면 될듯
	
    public void OnBeginDrag(PointerEventData eventData) {
		transform.parent = GameObject.Find("CardMainCanvas").transform;
    }
	public void OnDrag(PointerEventData eventData) {
		transform.position = new Vector3( targetCamera.ScreenToWorldPoint(eventData.position).x, targetCamera.ScreenToWorldPoint(eventData.position).y, 0.0f);
		transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
	}

	public void OnEndDrag(PointerEventData eventData) {
		transform.parent = GameObject.Find("Cards").transform;
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
}
