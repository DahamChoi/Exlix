using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IBattleInterface {
	void PlayCard();
	void EndTurn();
	void OnEnemyAttack();
	void OnEnemyDebuff();
	void OnEnemyBuff();
	void OnDrawCard();
	void OnRestoreMana();
	void OnHeal();
	void OnPlayerBuff();
	void OnUseMana();
	void OnShieldUp();
	void StartTurn();
	void OnDead();
	void OnEnemyDead();
	void OnSomethingSpecailEffect();
}