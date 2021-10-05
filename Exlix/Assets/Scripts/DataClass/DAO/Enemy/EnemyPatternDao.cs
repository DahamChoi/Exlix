using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatternDao 
{
    private static readonly string EnemyPatternTable = "enemy_pattern";
    private static readonly string EnemyPatternTypeTable = "enemy_pattern_type";

    public static EnemyPattern GetEnemyPattern(int patternIndex) {
        string query =
            $"SELECT" +
            $"{EnemyPatternTypeTable}.ko_KR AS 'enemy_pattern_type'," +
            $"{EnemyPatternTable}.pattern_path AS 'pattern_path'," +
            $"FROM {EnemyPatternTable}" +
            $"LEFT JOIN {EnemyPatternTypeTable}" +
            $"ON {EnemyPatternTable}.enemy_pattern_type_index = {EnemyPatternTypeTable}.enemy_pattern_type_index" +
            $"WHERE {EnemyPatternTable}.enemy_pattern_index = {patternIndex}";

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
