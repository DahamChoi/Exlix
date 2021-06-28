using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonster : BattleObject {
    private int Next_Pattern;
    private readonly int Attack;

    public const int E_MONSTER_PATTERN_ATTACK = (1 << 0);
    public const int E_MONSTER_PATTERN_DEFENSE = (1 << 1);
    public const int E_MONSTER_PATTERN_HEAL = (1 << 2);
    public const int E_MONSTER_BUFF = (1 << 3);
    public const int E_MONSTER_DEBUFF = (1 << 4);
    public const int E_MONSTER_SECERT = (1 << 5);

    public BattleMonster(int hp, int attack) : base(hp) {
        Attack = attack;
    }

    public void StartMonsterTurn() {
        Next_Pattern = (1 << Random.Range((1 << 0), (1 << 5) + 1));
    }

    public void ExecutePattern(BattlePlayer player) {
        player.TakeDamage(-Attack);
    }

    public List<int> GetNextPattern() {
        List<int> result = new List<int>();

        if ((Next_Pattern & E_MONSTER_PATTERN_ATTACK) > 0) {
            result.Add(E_MONSTER_PATTERN_ATTACK);
        }

        if ((Next_Pattern & E_MONSTER_PATTERN_DEFENSE) > 0) {
            result.Add(E_MONSTER_PATTERN_DEFENSE);
        }

        if ((Next_Pattern & E_MONSTER_PATTERN_HEAL) > 0) {
            result.Add(E_MONSTER_PATTERN_HEAL);
        }

        if ((Next_Pattern & E_MONSTER_BUFF) > 0) {
            result.Add(E_MONSTER_BUFF);
        }

        if ((Next_Pattern & E_MONSTER_DEBUFF) > 0) {
            result.Add(E_MONSTER_DEBUFF);
        }

        if ((Next_Pattern & E_MONSTER_SECERT) > 0) {
            result.Add(E_MONSTER_SECERT);
        }

        return result;
    }
}
