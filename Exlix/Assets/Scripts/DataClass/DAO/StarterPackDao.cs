using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class StarterPackDao
{
    private static readonly string StarterPackTable = "starter_pack";
    private static readonly string StarterPackName ="starter_pack_name";
    private static readonly string StarterPackDescribe = "starter_pack_descirbe";
    private static readonly string StarterPackRequire = "starter_pack_req";
    private static readonly string StarterPackRequireDescribe = "starter_pack_req_describe";
    public static StarterPack GetStarterPack(int index) {
        string query = $"SELECT" +
            $"{StarterPackTable}.starter_pack_index AS 'starter_pack_index'," +
            $"{StarterPackTable}.card_list AS 'card_list'," +
            $"{StarterPackName}.ko_KR AS 'name'," +
            $"{StarterPackDescribe}.ko_KR AS 'describe'," +
            $"{StarterPackTable}.image_path AS 'image_path'," +
            $"{StarterPackRequire}.is_unlocked AS 'is_unlocked'," +
            $"{StarterPackRequireDescribe}.ko_KR AS 'unlock_req_text'" +
            $"FROM {StarterPackTable}" +
            $"LEFT JOIN {StarterPackName}" +
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackName}.starter_pack_index" +
            $"LEFT JOIN starter_pack_req" +
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackRequire}.starter_pack_index" +
            $"LEFT JOIN starter_pack_describe" +
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackDescribe}.starter_pack_index" +
            $"LEFT JOIN starter_pack_req_describe" +
            $"ON {StarterPackTable}.starter_pack_index = {StarterPackRequireDescribe}.starter_pack_index"+
            $"WHERE {StarterPackTable}.starter_pack_index = {index}";

        StarterPack starterPack = new StarterPack();
        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        
        //starterPack.cardList = it.GetSafeValue<>
        //starterPack.name = it.GetSafeValue<string>(3);


        return starterPack;
    }
}
