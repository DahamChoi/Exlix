using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDao
{
    private static readonly string BattleTable = "battle";
    private static readonly string BattleFieldTable = "battlefield";

    public static Battle GetBattle(int battleIndex) {
        string query =
            $"SELECT" +
            $"{BattleTable}.enemy_list AS 'enemy_list'," +
            $"{BattleFieldTable}.illust_index AS 'illust_index'," +
            $"{BattleFieldTable}.bgm_path AS 'bgm_path'" +
            $"FROM {BattleTable}" +
            $"LEFT JOIN {BattleFieldTable}" +
            $"ON {BattleTable}.battlefield_index = {BattleFieldTable}.battlefield_index" +
            $"WHERE {BattleTable}.battle_index = {battleIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Battle battle = new Battle();

        List<int> enemyIndexList = it.GetTextValueToList(1);
        List<Enemy> enemyList = new List<Enemy>();
        for (int i =0; i<enemyIndexList.Count; i++) {
            enemyList.Add(EnemyDao.GetEnemy(enemyIndexList[i]));
        }

        battle.enemyList = enemyList;
        battle.battlefield.illust = IllustrationDao.GetIllust(it.GetSafeValue<int>(2));
        battle.battlefield.bgmPath = it.GetSafeValue<string>(3);

        return battle;
    }
}
