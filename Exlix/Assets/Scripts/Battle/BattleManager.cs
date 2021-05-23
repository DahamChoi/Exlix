using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : IBattleInterface {

    private CSVCardParser CardParser = new CSVCardParser("");
    public BattlePlayer Player;
    public BattleEnemy Enemy;

    public BattleManager() {
        List<uint> deck = new List<uint>(){ 1, 2, 3, 4, 5, 6 };
        Player = new BattlePlayer(deck, 0, 0);
    }

    public void StartPlayerTurn() {
        for(int i = 0; i < 5; i++) {
            Player.DrawCard();
        }
    }

    public void SplashCard(CardDataTemplate CardData, List<BattleEnemy> Enemyies) {
        Player.SplashCard(CardData);
    }

    public void EndPlayerTurn() {

    }

    public void StartEnemyTurn() {

    }

    public void EndEnemyTurn() {

    }

	public void PlayCard() {

	}

	public void EndTurn() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyAttack() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyDebuff() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyBuff() {
		throw new System.NotImplementedException();
	}

	public void OnDrawCard() {
		throw new System.NotImplementedException();
	}

	public void OnRestoreMana() {
		throw new System.NotImplementedException();
	}

	public void OnHeal() {
		throw new System.NotImplementedException();
	}

	public void OnPlayerBuff() {
		throw new System.NotImplementedException();
	}

	public void OnUseMana() {
		throw new System.NotImplementedException();
	}

	public void OnShieldUp() {
		throw new System.NotImplementedException();
	}

	public void StartTurn() {
		throw new System.NotImplementedException();
	}

	public void OnDead() {
		throw new System.NotImplementedException();
	}

	public void OnEnemyDead() {
		throw new System.NotImplementedException();
	}

	public void OnSomethingSpecailEffect() {
		throw new System.NotImplementedException();
	}
}
