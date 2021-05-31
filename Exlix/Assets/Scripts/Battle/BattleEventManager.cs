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

	public void OnDrawCard(BattlePlayer player) {
		//손에 있는 카드 오브젝트 리스트
		CardHand cardHand = GameObject.Find("HandCanvas").GetComponent<CardHand>();
		CardTransformChanger transformChanger = GameObject.Find("GameManager").GetComponent<CardTransformChanger>();
		//카드 프리펩을 특정위치에 생성후 패 리스트에 추가
		GameObject tempCard = Instantiate(cardHand.exampleCard, transformChanger.DeckPosition.position, transformChanger.DeckPosition.rotation, cardHand.handCanvas.transform);
		tempCard.GetComponent<TestCardText>().ReadText(player.Hand[player.Hand.Count-1]);
		cardHand.CardObjects.Add(tempCard);

		tempCard.name = "Card:" + (cardHand.CardObjects.Count).ToString();
		//카드가 패로 들어올때 애니메이션 필요하다면 추가 예정
		transformChanger.AddCardToHand(ref tempCard);
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

    public void OnMonsterReady(List<BattleMonster> monster) {
        //throw new System.NotImplementedException();
    }

    public void OnPlayCard(List<BattleMonster> monster, BattlePlayer player)
    {
        throw new System.NotImplementedException();
    }
}
