using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class StarterPackDao
{
    private static readonly string StarterPackTable = "starter_pack";
    private static readonly string StarterPackName ="starter_pack_name";
    private static readonly string StarterPackDescribe = "starter_pack_describe";
    private static readonly string StarterPackRequire = "starter_pack_req";
    private static readonly string StarterPackRequireDescribe = "starter_pack_req_describe";
    private static readonly string IllustTable = "illust";
    public static StarterPack GetStarterPack(int index) {
        string query = $"SELECT " + 
            $"{StarterPackTable}.starter_pack_index AS 'starter_pack_index', " + 
            $"{StarterPackTable}.card_list AS 'card_list', " + 
            $"{StarterPackName}.ko_KR AS 'name', " + 
            $"{StarterPackDescribe}.ko_KR AS 'describe', " + 
            $"{IllustTable}.image_path AS 'image_path'," + 
            $"{StarterPackRequire}.is_unlocked AS 'is_unlocked', " + 
            $"{StarterPackRequireDescribe}.ko_KR AS 'unlock_req_text' " + 
            $"FROM {StarterPackTable} " + 
            $"LEFT JOIN {StarterPackName} " + 
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackName}.starter_pack_index " + 
            $"LEFT JOIN {StarterPackRequire} " + 
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackRequire}.starter_pack_index " + 
            $"LEFT JOIN {StarterPackDescribe} " + 
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackDescribe}.starter_pack_index " + 
            $"LEFT JOIN {StarterPackRequireDescribe} " + 
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackRequireDescribe}.starter_pack_index" + 
            $"LEFT JOIN {IllustTable}" + 
            $"ON {IllustTable}.illust_index = {IllustTable}.illust_index" + 
            $"WHERE {StarterPackTable}.starter_pack_index = {index}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        StarterPack starterPack = new StarterPack();
        //starterPack.cardList = it.GetSafeValue<1>
        starterPack.name.textKr = it.GetSafeValue<string>(2);
        starterPack.describe.textKr = it.GetSafeValue<string>(3);
        starterPack.Illust.imagePath = it.GetSafeValue<string>(4);
        starterPack.requirement.IsUnlocked = it.GetSafeValue<bool>(5);
        starterPack.describe.textKr = it.GetSafeValue<string>(6);

        return starterPack;
    }
}
