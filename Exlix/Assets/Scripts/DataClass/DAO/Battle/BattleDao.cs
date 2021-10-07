using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDao
{
    public static Battle GetBattle(int battleIndex) {
        string query =
            $"SELECT" +
            $"{DataBaseTableDefine.BattleTable}.enemy_list AS 'enemy_list'," +
            $"{DataBaseTableDefine.BattleFieldTable}.illust_index AS 'illust_index'," +
            $"{DataBaseTableDefine.BattleFieldTable}.bgm_path AS 'bgm_path'" +
            $"FROM {DataBaseTableDefine.BattleTable}" +
            $"LEFT JOIN {DataBaseTableDefine.BattleFieldTable}" +
            $"ON {DataBaseTableDefine.BattleTable}.battlefield_index = {DataBaseTableDefine.BattleFieldTable}.battlefield_index" +
            $"WHERE {DataBaseTableDefine.BattleTable}.battle_index = {battleIndex}";

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
