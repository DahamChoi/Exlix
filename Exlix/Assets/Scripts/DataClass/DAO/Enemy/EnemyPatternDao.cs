using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternDao 
{
    public static EnemyPattern GetEnemyPattern(int patternIndex) {
        string query =
            $"SELECT" +
            $"{DataBaseTableDefine.EnemyPatternTypeTable}.ko_KR AS 'enemy_pattern_type'," +
            $"{DataBaseTableDefine.EnemyPatternTable}.pattern_path AS 'pattern_path'," +
            $"FROM {DataBaseTableDefine.EnemyPatternTable}" +
            $"LEFT JOIN {DataBaseTableDefine.EnemyPatternTypeTable}" +
            $"ON {DataBaseTableDefine.EnemyPatternTable}.enemy_pattern_type_index = {DataBaseTableDefine.EnemyPatternTypeTable}.enemy_pattern_type_index" +
            $"WHERE {DataBaseTableDefine.EnemyPatternTable}.enemy_pattern_index = {patternIndex}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        EnemyPattern enemyPattern = new EnemyPattern();

        enemyPattern.patternType = it.GetSafeValue<string>(1);
        enemyPattern.patternPath = it.GetSafeValue<string>(2);

        return enemyPattern;
    }
}
