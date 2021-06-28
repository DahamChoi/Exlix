using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleInterface {
    void OnMonsterReady(List<BattleMonster> monster);
	void OnPlayCard(GameObject card);
	void OnEndEnemyTurn();
	void OnEnemyAttack();
	void OnEnemyDebuff();
	void OnEnemyBuff();
	void OnDrawCard(BattlePlayer player);
	void OnRestoreMana();
	void OnHeal();
	void OnDamaged(BattlePlayer player);
	void OnPlayerBuff();
	void OnUseMana();
	void OnShieldUp();
	void StartTurn();
	void OnDead();
	void OnEnemyDead();
	void OnSomethingSpecailEffect();
}