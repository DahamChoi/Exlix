using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDao
{
    public static Enemy GetEnemy(int enemyIndex) {
        string query =
            $"SELECT " +
           $"{DataBaseTableDefine.EnemyTable}.hp AS 'hp', " +
           $"{DataBaseTableDefine.EnemyNameTable}.ko_KR AS 'name', " +
           $"{DataBaseTableDefine.EnemyTable}.enemy_pattern_list AS 'enemy_pattern_list', " +
           $"{DataBaseTableDefine.EnemyTable}.illust_index AS 'illust_index' " +
           $"FROM {DataBaseTableDefine.EnemyTable} " +
           $"LEFT JOIN {DataBaseTableDefine.EnemyNameTable} " +
           $"ON {DataBaseTableDefine.EnemyTable}.enemy_index = {DataBaseTableDefine.EnemyNameTable}.enemy_index " +
           $"WHERE {DataBaseTableDefine.EnemyTable}.enemy_index = {enemyIndex} ";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Enemy enemy = new Enemy();
        JsonParser jsonParser = new JsonParser();

        //hp&name
        enemy.hp = it.GetSafeValue<int>(0);
        enemy.name = it.GetSafeValue<string>(1);

        //enemyPatternList
        List<int> enemyPatternIndexList = jsonParser.JsonToObject<List<int>>(it.GetSafeValue<string>(2));
        List<EnemyPattern> enemyPatternList = new List<EnemyPattern>();
       
        for (int i = 0; i < enemyPatternIndexList.Count; i++) {
            EnemyPattern pattern = EnemyPatternDao.GetEnemyPattern(enemyPatternIndexList[i]);
            enemyPatternList.Add(pattern);
        }

        enemy.enemyPattern = enemyPatternList;
        
        //Illust
        enemy.illust = IllustrationDao.GetIllust(it.GetSafeValue<int>(3));

        return enemy;
    }
}
