using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusDao 
{
    public static CharacterStatus GetCharacterStatus() {
        string query =
        $"SELECT" +
        $"{DataBaseTableDefine.StatusTable}.name AS 'name'," +
        $"{DataBaseTableDefine.StatusTable}.gold AS 'gold'," +
        $"{DataBaseTableDefine.StatusTable}.level AS 'level'," +
        $"{DataBaseTableDefine.StatusTable}.exp AS 'exp'," +
        $"{DataBaseTableDefine.StatusTable}.skill_point AS 'skill_point'," +
        $"{DataBaseTableDefine.StatusTable}.status_point AS 'status_point'" +
        $"FROM {DataBaseTableDefine.StatusTable} WHERE {DataBaseTableDefine.StatusTable}.character_index = 1";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }
        CharacterStatus status = new CharacterStatus();
        status.name = it.GetSafeValue<string>(1);
        status.gold = it.GetSafeValue<int>(2);
        status.level = it.GetSafeValue<int>(3);
        status.exp = it.GetSafeValue<int>(4);
        status.skillPoint = it.GetSafeValue<int>(5);
        status.statusPoint = it.GetSafeValue<int>(6);

        return status;
    }


}
