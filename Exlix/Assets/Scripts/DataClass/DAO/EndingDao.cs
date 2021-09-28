using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDao
{
    private static readonly string EndingTable = "ending";
    private static readonly string EndingTitleTable = "ending_title";
    private static readonly string EndingDescribeTable = "ending_describe";
    private static readonly string IllustTable = "illust";

    public static Ending GetEnding() {
        string query =
            $"SELECT " +
            $"{EndingTable}.ending_index AS 'ending_index', " +
            $"{EndingTitleTable}.ko_KR AS 'ending_title', " +
            $"{EndingDescribeTable}.ko_KR AS 'ending_describe', " +
            $"{IllustTable}.image_path AS 'image_path'" +
            $"FROM {EndingTable} " +
            $"LEFT JOIN {EndingTitleTable} " +
            $"ON {EndingTable}.ending_index = {EndingTitleTable}.ending_index " +
            $"LEFT JOIN {EndingDescribeTable} " +
            $"ON {EndingTable}.ending_index = {EndingDescribeTable}.ending_index " +
            $"LEFT JOIN {IllustTable} " +
            $"ON {EndingTable}.illust_index = {IllustTable}.illust_index";

        ExdioDataReader it = SQLiteManager.GetInstance().SelectQuery(query);
        
        if (false == it.Read()) {
            return default;
        }

        Ending ending = new Ending();

        ending.endingIndex = it.GetSafeValue<int>(1);
        ending.endingTitle = it.GetSafeValue<string>(2);
        ending.endingDescribe = it.GetSafeValue<string>(3);
        ending.illust.imagePath = it.GetSafeValue<string>(4);

        return ending;
    }
}
