using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class StarterPackDao
{
    public static StarterPack GetStarterPack(int index) {
        string query = $"SELECT " + 
            $"{DataBaseTableDefine.StarterPackTable}.starter_pack_index AS 'starter_pack_index', " + 
            $"{DataBaseTableDefine.StarterPackTable}.card_list AS 'card_list', " + 
            $"{DataBaseTableDefine.StarterPackName}.ko_KR AS 'name', " + 
            $"{DataBaseTableDefine.StarterPackDescribe}.ko_KR AS 'describe', " + 
            $"{DataBaseTableDefine.IllustTable}.image_path AS 'image_path'," + 
            $"{DataBaseTableDefine.StarterPackRequire}.is_unlocked AS 'is_unlocked', " + 
            $"{DataBaseTableDefine.StarterPackRequireDescribe}.ko_KR AS 'unlock_req_text' " + 
            $"FROM {DataBaseTableDefine.StarterPackTable} " + 
            $"LEFT JOIN {DataBaseTableDefine.StarterPackName} " + 
            $"ON {DataBaseTableDefine.StarterPackTable}.starter_pack_index = {DataBaseTableDefine.StarterPackName}.starter_pack_index " + 
            $"LEFT JOIN {DataBaseTableDefine.StarterPackRequire} " + 
            $"ON {DataBaseTableDefine.StarterPackTable}.starter_pack_index = {DataBaseTableDefine.StarterPackRequire}.starter_pack_index " + 
            $"LEFT JOIN {DataBaseTableDefine.StarterPackDescribe} " + 
            $"ON {DataBaseTableDefine.StarterPackTable}.starter_pack_index = {DataBaseTableDefine.StarterPackDescribe}.starter_pack_index " + 
            $"LEFT JOIN {DataBaseTableDefine.StarterPackRequireDescribe} " + 
            $"ON {DataBaseTableDefine.StarterPackTable}.starter_pack_index = {DataBaseTableDefine.StarterPackRequireDescribe}.starter_pack_index" + 
            $"LEFT JOIN {DataBaseTableDefine.IllustTable}" + 
            $"ON {DataBaseTableDefine.IllustTable}.illust_index = {DataBaseTableDefine.IllustTable}.illust_index" + 
            $"WHERE {DataBaseTableDefine.StarterPackTable}.starter_pack_index = {index}";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);

        if (false == it.Read()) {
            return default;
        }

        StarterPack starterPack = new StarterPack();
        starterPack.starterPackIndex = it.GetSafeValue<int>(0);
        //starterPack.cardList = it.GetSafeValue<1>
        starterPack.name.textKr = it.GetSafeValue<string>(2);
        starterPack.describe.textKr = it.GetSafeValue<string>(3);
        starterPack.Illust.imagePath = it.GetSafeValue<string>(4);
        starterPack.requirement.IsUnlocked = it.GetSafeValue<bool>(5);
        starterPack.describe.textKr = it.GetSafeValue<string>(6);

        return starterPack;
    }
}
