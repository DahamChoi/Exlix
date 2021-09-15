using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattleStatusDao : MonoBehaviour
{
    private static readonly string BattleStatusTable = "character_battle_status";

    public static CharacterBattleStatus GetCharacterBattleStatus() {
        string query =
            $"SELECT" +
            $"{BattleStatusTable}.stat_hp AS 'stat_hp'," +
            $"{BattleStatusTable}.stat_str AS 'stat_str'," +
            $"{BattleStatusTable}.stat_int AS 'stat_int'," +
            $"{BattleStatusTable}.stat_dex AS 'stat_dex'," +
            $"{BattleStatusTable}.hp AS 'hp'," +
            $"{BattleStatusTable}.current_hp AS 'current_hp'," +
            $"{BattleStatusTable}.mp AS 'mp'," +
            $"{BattleStatusTable}.current_mp AS 'current_mp'" +
            $"FROM {BattleStatusTable} WHERE {BattleStatusTable}.character_index = 1";
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        if (false == it.Read()) {
            return default;
        }
        CharacterBattleStatus status = new CharacterBattleStatus();
        status.stat_hp = it.GetSafeValue<int>(1);
        status.stat_str = it.GetSafeValue<int>(2);
        status.stat_int = it.GetSafeValue<int>(3);
        status.stat_dex = it.GetSafeValue<int>(4);
        status.hp = it.GetSafeValue<int>(5);
        status.current_hp = it.GetSafeValue<int>(6);
        status.mp = it.GetSafeValue<int>(7);
        status.current_mp = it.GetSafeValue<int>(8);

        return status;
    }
}
