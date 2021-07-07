using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class CharacterInfoDAO {
    static string CharacterInfoTableName = "character_info";

    static void UpsertPlayerStat(SQLiteManager sqliteManager, int hp, int str, int Intellect, int dex) {
        string query = 
            $"INSERT OR REPLACE INTO {CharacterInfoTableName}(number, stat_hp, stat_str, stat_int, stat_dex)" +
            $"VALUES({hp}, {str}, {Intellect}, {dex});";
        sqliteManager.InsertQuery(query);
    }
}
