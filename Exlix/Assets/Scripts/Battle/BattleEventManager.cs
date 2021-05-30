using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEventManager : MonoBehaviour, IBattleInterface {
	void Start() {

	}

	void Update() {

	}

	public void OnDead() {
		throw new System.NotImplementedException();
	}

	public void OnDrawCard() {
		//덱의 가장 위의 카드
		CardDataTemplate tCard = GameObject.Find("GameManager").GetComponent<GameManager>().CardParser.DataList[0];
		//손에 있는 카드 리스트
		TestCardHand handCard = GameObject.Find("GameManager").GetComponent<TestCardHand>();
		CardTransformChanger transformChanger = GameObject.Find("GameManager").GetComponent<CardTransformChanger>();
		//패의 숫자가 허용치를 넘어갔을때의 예외처리
		if (handCard.testCards.Count >= handCard.maxCard) return;
		//카드 프리펩을 특정위치에 생성후 패 리스트에 추가
		GameObject tempCard = Instantiate(handCard.exampleCard, transformChanger.DeckPosition.position, transformChanger.DeckPosition.rotation, handCard.handCanvas.transform);
		tempCard.GetComponent<TestCardText>().ReadText(tCard);
		handCard.testCards.Add(tempCard);

		tempCard.name = "Card:" + (handCard.testCards.Count).ToString();
		transformChanger.AddCardToHand(tempCard);
		//카드가 패로 들어올때 애니메이션 필요하다면 추가 예정
		//카드가 패로 들어왔을때 도착 위치 조정 추가 예정
	}

	public void OnEndEnemyTurn() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyAttack() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyBuff() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyDead() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyDebuff() {
		throw new System.NotImplementedException();
	}

	public void OnHeal() {
		throw new System.NotImplementedException();
	}

	public void OnDamaged(float dmg) {
		TestBattlePlayer Player = GameObject.Find("Player").GetComponent<TestBattlePlayer>();
		TestBattlePlayerHp pHPBar = GameObject.Find("Player").GetComponent<TestBattlePlayerHp>();

		Player.PlayerCurrentHP -= dmg;
		pHPBar.Dmg();
	}

	public void OnPlayCard() {
		throw new System.NotImplementedException();
	}

	public void OnPlayerBuff() {
		throw new System.NotImplementedException();
	}

	public void OnRestoreMana() {
		throw new System.NotImplementedException();
	}

	public void OnShieldUp() {
		throw new System.NotImplementedException();
	}

	public void OnSomethingSpecailEffect() {
		throw new System.NotImplementedException();
	}

	public void OnUseMana() {

	}

	public void StartTurn() {
		throw new System.NotImplementedException();
	}
}
