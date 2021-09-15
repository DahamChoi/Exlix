using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusDao 
{
    private static readonly string StatusTable = "character_status";
    public static CharacterStatus GetCharacterStatus() {
        string query =
        $"SELECT" +
       $"{StatusTable}.name AS 'name'," +
       $"{StatusTable}.gold AS 'gold'," +
       $"{StatusTable}.level AS 'level'," +
       $"{StatusTable}.exp AS 'exp'," +
       $"{StatusTable}.skill_point AS 'skill_point'," +
       $"{StatusTable}.status_point AS 'status_point'" +
       $"FROM {StatusTable} WHERE {StatusTable}.character_index = 1";
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
