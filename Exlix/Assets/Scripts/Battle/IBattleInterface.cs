using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleInterface {
	void OnPlayCard();
	void OnEndEnemyTurn();
	void OnEnemyAttack();
	void OnEnemyDebuff();
	void OnEnemyBuff();
	void OnDrawCard();
	void OnRestoreMana();
	void OnHeal();
	void OnDamaged(float dmg);
	void OnPlayerBuff();
	void OnUseMana();
	void OnShieldUp();
	void StartTurn();
	void OnDead();
	void OnEnemyDead();
	void OnSomethingSpecailEffect();
}