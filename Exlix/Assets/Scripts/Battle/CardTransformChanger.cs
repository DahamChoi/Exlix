using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardTransformChanger : MonoBehaviour {
	public float rotateAngle = 2.0f;
	public float rotateSpeed = 80.0f;
	public float slowMoveSpeed = 6.0f;
	public float cardBigScale = 0.9f;
	public float scaleSpeed = 10000.0f;
	public float moveSpeed = 10000.0f;
	public float cardNormalScale = 0.8f;
	public float sendCardMoveSpeed = 20.0f;
	public float sendCardScaleSpeed = 10.0f;
	public Vector3 centerPoint = new Vector3(0.0f, -50.0f, 0.0f);

	public Transform HandPosition;
	public Transform DeckPosition;
	public Transform GravePosition;
	float centerRadius = 46.0f;//centerPoint로부터 카드의 postition까지의 반지름

	CardHand cardHand;

	public void AddCardToHand(ref GameObject instanceCard) {
		CardTransformData card = instanceCard.GetComponent<CardTransformData>();
		card.MoveSpeed = sendCardMoveSpeed;
		card.TargetScale = cardNormalScale;
		card.ScaleSpeed = sendCardScaleSpeed;

		CalCardsTransform();
	}

	public void CalCardsTransform() {
		if (!cardHand) cardHand = GameObject.Find("HandCanvas").GetComponent<CardHand>();
		int i = 0;
		foreach (var card in cardHand.CardObjects) {
			CardTransformData cardTransformData = card.GetComponent<CardTransformData>();
			cardTransformData.TargetAngle = OriginalAngle(i);
			cardTransformData.TargetPosition = GetHandPosition(i);
			card.GetComponent<CardDataContainer>().cardIndexNum = i;
			card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y, 0.0f);
			card.GetComponent<SpriteRenderer>().sortingOrder = i++;
		}
	}

	float OriginalAngle(int idx) {
		float leftAngle = (cardHand.CardObjects.Count - 1) * rotateAngle / 2;
		return leftAngle - idx * rotateAngle;
	}

	Vector3 GetHandPosition(int idx) {
		float angle = OriginalAngle(idx) + cardHand.CardObjects[idx].GetComponent<CardTransformData>().OffsetAngle;
		return new Vector3(centerPoint.x - centerRadius * Mathf.Sin(ConvertAngleToArc(angle)), centerPoint.y + centerRadius * Mathf.Cos(ConvertAngleToArc(angle)), 0.0f);
	}

	void UpdateCardRotate() {
		foreach (var card in cardHand.CardObjects) {
			CardTransformData cardTransformData = card.GetComponent<CardTransformData>();
			if (Mathf.Abs(cardTransformData.CurAngle - cardTransformData.TargetAngle) <= Time.fixedDeltaTime * rotateSpeed) {
				cardTransformData.CurAngle = cardTransformData.TargetAngle;
				card.transform.rotation = Quaternion.Euler(0, 0, cardTransformData.TargetAngle);
			}
			else if (cardTransformData.CurAngle > cardTransformData.TargetAngle) {
				cardTransformData.CurAngle -= Time.fixedDeltaTime * rotateSpeed;
				card.transform.Rotate(0, 0, -Time.fixedDeltaTime * rotateSpeed);
			}
			else {
				cardTransformData.CurAngle += Time.fixedDeltaTime * rotateSpeed;
				card.transform.Rotate(0, 0, Time.fixedDeltaTime * rotateSpeed);
			}
		}
	}

	void UpdateCardPosition() {
		foreach (var card in cardHand.CardObjects) {
			CardTransformData cardTransformData = card.GetComponent<CardTransformData>();
			card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y, 0.0f);
			card.transform.position = Vector3.Lerp(card.transform.position, cardTransformData.TargetPosition, Time.fixedDeltaTime * cardTransformData.MoveSpeed);
		}
	}

	static float ConvertAngleToArc(float angle) {
		return angle * Mathf.PI / 180;
	}

	public void SpreadCardPosition(int idx) {
		foreach (var card in cardHand.CardObjects) {
			CardTransformData cardTransformData = card.GetComponent<CardTransformData>();
			cardTransformData.TargetPosition += new Vector3((float)2 / (card.GetComponent<CardDataContainer>().cardIndexNum - idx) / 2, 0, 0);
		}
	}

	void Start() {
		cardHand = GameObject.Find("HandCanvas").GetComponent<CardHand>();
	}

	void Update() {

	}

	private void FixedUpdate() {
		UpdateCardRotate();
		UpdateCardPosition();
	}

}
