using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDao
{
    public static Enemy GetEnemy(int enemyIndex) {
        string query =
            $"SELECT" +
           $"{DataBaseTableDefine.EnemyTable}.hp AS 'hp'," +
           $"{DataBaseTableDefine.EnemyNameTable} AS 'name'," +
           $"{DataBaseTableDefine.EnemyTable}.enemy_pattern_list AS 'enemy_pattern_list'," +
           $"{DataBaseTableDefine.EnemyTable}.illust_index AS 'illust_index'" +
           $"FROM {DataBaseTableDefine.EnemyTable}" +
           $"LEFT JOIN {DataBaseTableDefine.EnemyNameTable}" +
           $"ON {DataBaseTableDefine.EnemyTable}.enemy_index ={DataBaseTableDefine.EnemyNameTable}.enemy_index" +
           $"WHERE {DataBaseTableDefine.EnemyTable}.enemy_index = {enemyIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        Enemy enemy = new Enemy();

        enemy.hp = it.GetSafeValue<int>(1);
        enemy.name = it.GetSafeValue<string>(2);
        
        List<int> enemyPatternIndexList = it.GetTextValueToList(3);
        int illustIndex = it.GetSafeValue<int>(4);

        enemy.illust = IllustrationDao.GetIllust(illustIndex);


        //이부분은 추후 변경 가능성 (Json)
        List<EnemyPattern> enemyPatternList = new List<EnemyPattern>();

        for(int i =0; i<enemyPatternIndexList.Count; i++) {
            EnemyPattern pattern = EnemyPatternDao.GetEnemyPattern(enemyPatternIndexList[i]);
            enemyPatternList.Add(pattern);    
        }

        enemy.enemyPattern = enemyPatternList;

        return enemy;
    }
}
